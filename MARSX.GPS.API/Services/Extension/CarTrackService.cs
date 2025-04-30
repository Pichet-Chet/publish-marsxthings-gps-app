using System;
using System.IO;
using System.Net;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Caec;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Reponse;
using Newtonsoft.Json;
using WatchDog;
using static System.Net.Mime.MediaTypeNames;

namespace MARSX.GPS.API.Services.Extension
{
    public class CarTrackService
    {
        IConfigurationRoot config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

        private readonly TrackerContext _context;

        private string _domain = string.Empty;

        public CarTrackService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> SyncDevice()
        {
            List<Vehicles> vehicleses = new List<Vehicles>();

            List<MachineMaster> machineMasters = new List<MachineMaster>();

            List<MachineModel> machineModels = new List<MachineModel>();

            List<CustomerMaster> customerMasters = new List<CustomerMaster>();

            List<MachinePhoto> machinePhotos = new List<MachinePhoto>();

            CaecResponse caecResponse = new CaecResponse();

            Response resp = new Response();

            try
            {
                #region API Zone

                string apiData = string.Empty;

                HttpClient client = new HttpClient();

                HttpResponseMessage response = new HttpResponseMessage();

                _domain = config["Caec:Api"];

                client.BaseAddress = new Uri(_domain + $"api/Vehicles");

                response = await client.GetAsync(client.BaseAddress);

                apiData = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                if (!string.IsNullOrEmpty(apiData))
                {
                    vehicleses = JsonConvert.DeserializeObject<List<Vehicles>>(apiData);
                }
                else
                {
                    vehicleses = new List<Vehicles>();
                }


                client = new HttpClient();

                response = new HttpResponseMessage();

                client.BaseAddress = new Uri(_domain + $"api/MachineMaster");

                response = await client.GetAsync(client.BaseAddress);

                apiData = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                if (!string.IsNullOrEmpty(apiData))
                {
                    caecResponse = new CaecResponse();

                    caecResponse = JsonConvert.DeserializeObject<CaecResponse>(apiData);

                    machineMasters = JsonConvert.DeserializeObject<List<MachineMaster>>(caecResponse.outpuT_DATA.ToString());

                }
                else
                {
                    vehicleses = new List<Vehicles>();
                }

                client = new HttpClient();

                response = new HttpResponseMessage();

                client.BaseAddress = new Uri(_domain + $"api/MachineModel");

                response = await client.GetAsync(client.BaseAddress);

                apiData = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                if (!string.IsNullOrEmpty(apiData))
                {
                    caecResponse = new CaecResponse();

                    caecResponse = JsonConvert.DeserializeObject<CaecResponse>(apiData);

                    machineModels = JsonConvert.DeserializeObject<List<MachineModel>>(caecResponse.outpuT_DATA.ToString());

                }
                else
                {
                    vehicleses = new List<Vehicles>();
                }


                client = new HttpClient();

                response = new HttpResponseMessage();

                client.BaseAddress = new Uri(_domain + $"api/CustomerMaster");

                response = await client.GetAsync(client.BaseAddress);

                apiData = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                if (!string.IsNullOrEmpty(apiData))
                {
                    caecResponse = new CaecResponse();

                    caecResponse = JsonConvert.DeserializeObject<CaecResponse>(apiData);

                    customerMasters = JsonConvert.DeserializeObject<List<CustomerMaster>>(caecResponse.outpuT_DATA.ToString());
                }
                else
                {
                    vehicleses = new List<Vehicles>();
                }

                client = new HttpClient();

                response = new HttpResponseMessage();

                client.BaseAddress = new Uri(_domain + $"api/MachinePhoto");

                response = await client.GetAsync(client.BaseAddress);

                apiData = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                if (!string.IsNullOrEmpty(apiData))
                {
                    caecResponse = new CaecResponse();

                    caecResponse = JsonConvert.DeserializeObject<CaecResponse>(apiData);

                    machinePhotos = JsonConvert.DeserializeObject<List<MachinePhoto>>(caecResponse.outpuT_DATA.ToString());
                }

                #endregion


                if (vehicleses != null && vehicleses.Count > 0)
                {
                    var carTrackDevice = await Task.Run(() => vehicleses.Select(x => Convert.ToString(x.vehicle_id)).ToList());

                    var masterDevices = await Task.Run(() => _context.MasterDevices.Where(x => x.MasterGpsProviderId == 1).Select(x => x.RefTrackingId).ToList());

                    var masterDevicesCategory = await Task.Run(() => _context.MasterDeviceCategories.ToList());

                    var masterPhotoTemp = await Task.Run(() => _context.MasterPhotos.ToList());

                    var tempMasterDevices = await Task.Run(() => _context.MasterDevices.ToList());

                    List<string> addingList = new List<string>();

                    List<string> updateList = new List<string>();

                    addingList = carTrackDevice.Except(masterDevices).ToList();

                    updateList = carTrackDevice.Union(masterDevices).ToList();


                    if (addingList != null && addingList.Count > 0)
                    {
                        List<MasterDevice> objList = new List<MasterDevice>();

                        List<MasterPhoto> objListMasterPhotos = new List<MasterPhoto>();

                        foreach (var item in addingList)
                        {
                            MasterDevice masterDevice = new MasterDevice();

                            MasterDeviceCategory masterDeviceCategory = new MasterDeviceCategory();

                            MachineMaster machineMaster = new MachineMaster();

                            MachineModel machineModel = new MachineModel();

                            CustomerMaster customerMaster = new CustomerMaster();

                            Vehicles vehicles = new Vehicles();

                            vehicles = vehicleses.Where(x => x.vehicle_id == Convert.ToInt32(item)).FirstOrDefault();

                            machineMasters = machineMasters.Where(x => x.mcSerialNo != null).ToList();

                            machineMaster = machineMasters.Where(x => x.mcSerialNo.ToLower() == vehicles.registration.ToLower()).FirstOrDefault();

                            machineMaster = machineMaster == null ? machineMasters.Where(x => x.mcChassis.ToLower().Trim() == vehicles.registration.ToLower().Trim()).FirstOrDefault() : machineMaster;

                            if (machineMaster != null)
                            {
                                machineModel = machineModels.Where(x => x.machineModelGobal.ToLower() == machineMaster.mcModelGobal.ToLower()).FirstOrDefault();

                                if (machineModel != null)
                                {
                                    masterDeviceCategory = masterDevicesCategory.Where(x => x.NameEn.ToLower().Trim() == machineModel.machineGroup.ToLower().Trim()).FirstOrDefault();
                                }
                                else
                                {
                                    masterDeviceCategory = null;
                                }

                                if (machineMaster.customerId != null)
                                {
                                    customerMasters = customerMasters.Where(x => x.customerId != null).ToList();

                                    customerMaster = customerMasters.Where(x => x.customerId == machineMaster.customerId).FirstOrDefault();
                                }
                                else
                                {
                                    customerMaster = null;
                                }
                            }
                            else
                            {
                                masterDeviceCategory = null;
                            }


                            masterDevice.MasterGpsProviderId = 1;
                            masterDevice.RefTrackingId = Convert.ToString(vehicles.vehicle_id);
                            masterDevice.MasterDeviceStatusId = 2;
                            masterDevice.MasterDeviceCategoryId = masterDeviceCategory == null ? Constants.MachineDeviceUnknownDefaultId : masterDeviceCategory.Id;
                            masterDevice.Name = vehicles.vehicle_name?.Trim();
                            masterDevice.Model = vehicles.model;
                            masterDevice.SerialNo = machineMaster == null ? null : machineMaster.mcSerialNo == null ? null : machineMaster.mcSerialNo;
                            masterDevice.Chassis = machineMaster == null ? null : machineMaster.mcChassis == null ? null : machineMaster.mcChassis;
                            masterDevice.CarNo = machineMaster == null ? masterDevice.CarNo : machineMaster.carNo == null ? masterDevice.CarNo : machineMaster.carNo;
                            masterDevice.CompanyOwnerName = machineMaster == null ? masterDevice.CompanyOwnerName : machineMaster.company_owner_name == null ? masterDevice.CompanyOwnerName : machineMaster.company_owner_name;
                            masterDevice.ModelYear = Convert.ToString(vehicles.model_year);
                            masterDevice.Manufacturer = vehicles.manufacturer;
                            masterDevice.Contact = machineMaster == null ? null : machineMaster.customerName == null ? null : machineMaster.customerName;
                            masterDevice.Phone = customerMaster == null ? null : customerMaster.telephone == null ? null : customerMaster.telephone.Replace("-", "").Trim();

                            masterDevice.Description = vehicles.client_vehicle_description;
                            masterDevice.IsActive = true;
                            masterDevice.CreateDate = DateTime.Now;
                            masterDevice.CreateBy = "Interface";
                            masterDevice.UpdateDate = DateTime.Now;
                            masterDevice.UpdateBy = "Interface";

                            //objList.Add(masterDevice);

                            _context.MasterDevices.Add(masterDevice);

                            _context.SaveChanges();

                            int newEntityId = masterDevice.Id;

                            if (machineMaster != null)
                            {
                               
                                List<MachinePhoto> findMachinePhotos = new List<MachinePhoto>();

                                findMachinePhotos = machinePhotos.Where(x => x.machineId == machineMaster.machineId).ToList();

                                if (findMachinePhotos != null && findMachinePhotos.Count > 0)
                                {
                                    

                                    foreach (var photo in findMachinePhotos)
                                    {
                                        var checkMasterPhotoDuplication = masterPhotoTemp.Where(x => x.MasterDeviceId == newEntityId && x.Location.Contains(photo.photoPath)).FirstOrDefault();

                                        if (checkMasterPhotoDuplication == null)
                                        {
                                            MasterPhoto masterPhoto = new MasterPhoto();

                                            var getPhotoName = "";
                                            var getPhotoType = "";
                                            double getPhotoMb = 0;

                                            int lastSlashIndex = photo.photoPath.LastIndexOf('/');
                                            int firstDotIndex = photo.photoPath.IndexOf('.', lastSlashIndex);
                                            if (lastSlashIndex != -1 && firstDotIndex != -1)
                                            {
                                                string result = photo.photoPath.Substring(lastSlashIndex + 1, firstDotIndex - lastSlashIndex - 1);
                                                getPhotoName = result;
                                            }
                                            else
                                            {
                                                getPhotoName = null;
                                            }

                                            int lastIndex = photo.photoPath.LastIndexOf('.');
                                            if (lastIndex != -1)
                                            {
                                                string result = photo.photoPath.Substring(lastIndex + 1);
                                                getPhotoType = result;
                                            }
                                            else
                                            {
                                                getPhotoType = null;
                                            }

                                            var pathImage = photo.photoPath;

                                            using (WebClient webclient = new WebClient())
                                            {
                                                
                                                int documentsIndex = photo.photoPath.IndexOf("documents", StringComparison.OrdinalIgnoreCase);

                                                if (documentsIndex != -1) // Check if "documents" was found
                                                {
                                                    string newPath = photo.photoPath.Substring(documentsIndex);

                                                    pathImage = "https://caecgroup.com/" + newPath;
                                                }
                                                else
                                                {
                                                    pathImage = "https://caecgroup.com/" + photo.photoPath;
                                                }

                                                byte[] data = webclient.DownloadData(pathImage);

                                                long fileSizeInBytes = data.Length;

                                                double fileSizeInMB = fileSizeInBytes / 1024.0 / 1024.0;

                                                getPhotoMb = fileSizeInMB;
                                            }


                                            masterPhoto.Categery = "MACHINE";
                                            masterPhoto.Label = photo.photoLabel;
                                            masterPhoto.Name = getPhotoName;
                                            masterPhoto.Type = getPhotoType;
                                            masterPhoto.Size = Convert.ToString(getPhotoMb.ToString("N2"));
                                            masterPhoto.SizeUnit = "mb";
                                            masterPhoto.Location = pathImage;
                                            masterPhoto.IsActive = true;
                                            masterPhoto.CreateDate = DateTime.Now;
                                            masterPhoto.CreateBy = "Interface";
                                            masterPhoto.UpdateDate = DateTime.Now;
                                            masterPhoto.UpdateBy = "Interface";
                                            masterPhoto.MasterDeviceId = newEntityId;

                                            objListMasterPhotos.Add(masterPhoto);
                                        }
                                    }
                                }
                            }

                            else
                            {

                            }
                        }

                        await _context.MasterPhotos.AddRangeAsync(objListMasterPhotos);

                        _context.SaveChanges();

                        //await _context.MasterDevices.AddRangeAsync(objList);

                        //_context.SaveChanges();

                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusSuccess;
                        resp.statusCode = Constants.statusCodeOK;
                        resp.type = Constants.msgSuccess;
                        resp.message = Constants.dataHasBeenSaved;
                        resp.effectRow = objList.Count();
                        resp.data = "";

                    }

                    if (updateList != null && updateList.Count > 0)
                    {
                        List<MasterDevice> objList = new List<MasterDevice>();

                        foreach (var item in updateList)
                        {
                            MasterDevice masterDevice = new MasterDevice();

                            MasterDeviceCategory masterDeviceCategory = new MasterDeviceCategory();

                            MachineMaster machineMaster = new MachineMaster();

                            MachineModel machineModel = new MachineModel();

                            CustomerMaster customerMaster = new CustomerMaster();

                            Vehicles vehicles = new Vehicles();

                            vehicles = vehicleses.Where(x => x.vehicle_id == Convert.ToInt32(item)).FirstOrDefault();

                            machineMasters = machineMasters.Where(x => x.mcSerialNo != null).ToList();

                            machineMaster = machineMasters.Where(x => x.mcSerialNo.ToLower().Trim() == vehicles.registration.ToLower().Trim()).FirstOrDefault();

                            machineMaster = machineMaster == null ? machineMasters.Where(x => x.mcChassis.ToLower().Trim() == vehicles.registration.ToLower().Trim()).FirstOrDefault() : machineMaster;

                            if (machineMaster != null)
                            {
                                machineModel = machineModels.Where(x => x.machineModel1?.ToLower().Trim() == machineMaster.mcModelGobal.ToLower().Trim()).FirstOrDefault();

                                if (machineModel != null)
                                {
                                    masterDeviceCategory = masterDevicesCategory.Where(x => x.NameEn.ToLower().Trim() == machineModel.machineGroup.Trim().ToLower()).FirstOrDefault();
                                }
                                else
                                {
                                    masterDeviceCategory = null;
                                }

                                if (machineMaster.customerId != null)
                                {
                                    customerMasters = customerMasters.Where(x => x.customerId != null).ToList();

                                    customerMaster = customerMasters.Where(x => x.customerId == machineMaster.customerId).FirstOrDefault();
                                }
                                else
                                {
                                    customerMaster = null;
                                }
                            }
                            else
                            {
                                masterDeviceCategory = null;
                            }

                            masterDevice = tempMasterDevices.Where(x => x.RefTrackingId == Convert.ToString(vehicles.vehicle_id)).FirstOrDefault();

                            if (masterDevice != null)
                            {
                                if (masterDevice.Name == null)
                                {
                                    masterDevice.Name = vehicles.vehicle_name != null ? vehicles.vehicle_name.Trim() : vehicles.registration == null ? "Unknow" : vehicles.registration.Trim();
                                }
                                else
                                {
                                    masterDevice.Name = masterDevice.Name == null ? masterDevice.Name : masterDevice.Name.Trim();
                                }

                                masterDevice.MasterDeviceCategoryId = masterDeviceCategory == null ? Constants.MachineDeviceUnknownDefaultId : masterDeviceCategory.Id;

                                masterDevice.SerialNo = machineMaster == null ? masterDevice.SerialNo : machineMaster.mcSerialNo == null ? masterDevice.SerialNo : machineMaster.mcSerialNo;
                                masterDevice.Chassis = machineMaster == null ? masterDevice.Chassis : machineMaster.mcChassis == null ? masterDevice.Chassis : machineMaster.mcChassis;
                                masterDevice.CarNo = machineMaster == null ? masterDevice.CarNo : machineMaster.carNo == null ? masterDevice.CarNo : machineMaster.carNo;
                                masterDevice.CompanyOwnerName = machineMaster == null ? masterDevice.CompanyOwnerName : machineMaster.company_owner_name == null ? masterDevice.CompanyOwnerName : machineMaster.company_owner_name;
                                masterDevice.ModelYear = vehicles == null ? masterDevice.ModelYear : vehicles.model_year == null ? masterDevice.ModelYear : Convert.ToString(vehicles.model_year);
                                masterDevice.Manufacturer = vehicles == null ? masterDevice.Manufacturer : vehicles.manufacturer == null ? masterDevice.Manufacturer : vehicles.manufacturer;
                                masterDevice.Contact = machineMaster == null ? masterDevice.Contact : machineMaster.customerName == null ? masterDevice.Contact : machineMaster.customerName;
                                masterDevice.Phone = customerMaster == null ? masterDevice.Phone : customerMaster.telephone == null ? masterDevice.Phone : customerMaster.telephone.Replace("-", "").Trim();
                                masterDevice.UpdateDate = DateTime.Now;
                                masterDevice.UpdateBy = "Interface";

                                objList.Add(masterDevice);
                            }
                        }

                        _context.MasterDevices.UpdateRange(objList);

                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                resp.message = ex.Message;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return resp;
        }

        public async Task<List<VehiclesLatestStatus>> GetVehiclesLatestStatusAll()
        {
            List<VehiclesLatestStatus> listData = new List<VehiclesLatestStatus>();

            try
            {
                HttpClient client = new HttpClient();

                _domain = config["Caec:Api"];

                client.BaseAddress = new Uri(_domain + $"api/VehiclesLatestStatus");

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);


                if (!string.IsNullOrEmpty(data))
                {
                    CaecResponse caecResponse = new CaecResponse();

                    caecResponse = JsonConvert.DeserializeObject<CaecResponse>(data);

                    if (caecResponse.outpuT_DATA != null)
                    {
                        listData = JsonConvert.DeserializeObject<List<VehiclesLatestStatus>>(caecResponse.outpuT_DATA.ToString());
                    }
                }
            }
            catch
            {

            }

            return listData;
        }

    }
}

