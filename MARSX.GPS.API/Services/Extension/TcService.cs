using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Caec;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Reponse;
using Newtonsoft.Json;
using WatchDog;

namespace MARSX.GPS.API.Services.Extension
{
    public class TcService
    {
        IConfigurationRoot config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

        private readonly TrackerContext _context;

        private string _domain = string.Empty;

        public TcService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> SyncDevice()
        {
            
            Response resp = new Response();

            CaecResponse caecResponse = new CaecResponse();

            List<MachineMaster> machineMasters = new List<MachineMaster>();

            List<MachineModel> machineModels = new List<MachineModel>();

            try
            {

                #region API Zone


                string apiData = string.Empty;

                HttpClient client = new HttpClient();

                HttpResponseMessage response = new HttpResponseMessage();

                _domain = config["Caec:Api"];

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
                    machineMasters = new List<MachineMaster>();
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
                    machineMasters = new List<MachineMaster>();
                }


                #endregion

                List<TcDevice> listData = new List<TcDevice>();

                listData = _context.TcDevices.ToList();

                if (listData != null && listData.Count > 0)
                {
                    var TcDevice = await Task.Run(() => listData.Select(x => Convert.ToString(x.Uniqueid)).ToList());

                    var masterDevices = await Task.Run(() => _context.MasterDevices.Where(x=>x.MasterGpsProviderId == 2).Select(x => x.RefTrackingId).ToList());

                    var masterDevicesCategory = await Task.Run(() => _context.MasterDeviceCategories.ToList());

                    var tempMasterDevices = await Task.Run(() => _context.MasterDevices.ToList());


                    List<string> addingList = new List<string>();

                    List<string> updateList = new List<string>();

                    addingList = TcDevice.Except(masterDevices).ToList();

                    updateList = TcDevice.Union(masterDevices).ToList();

                    if (addingList.Count != null && addingList.Count > 0)
                    {
                        List<MasterDevice> objList = new List<MasterDevice>();

                        foreach (var item in addingList)
                        {
                            MasterDevice masterDevice = new MasterDevice();

                            TcDevice tcDevice = new TcDevice();

                            tcDevice = listData.Where(x => x.Uniqueid == item).FirstOrDefault();

                            masterDevice.MasterGpsProviderId = 2;
                            masterDevice.RefTrackingId = tcDevice.Uniqueid;
                            masterDevice.MasterDeviceStatusId = 3;
                            masterDevice.Name = tcDevice.Name == null ? "Unknow" : tcDevice.Name.Trim();
                            masterDevice.Model = tcDevice.Model;
                            masterDevice.Contact = tcDevice.Contact;
                            masterDevice.Description = "";
                            masterDevice.IsActive = true;
                            masterDevice.CreateDate = DateTime.Now;
                            masterDevice.CreateBy = "Interface";
                            masterDevice.UpdateDate = DateTime.Now;
                            masterDevice.UpdateBy = "Interface";

                            objList.Add(masterDevice);
                        }

                        await _context.MasterDevices.AddRangeAsync(objList);

                        _context.SaveChanges();

                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusSuccess;
                        resp.statusCode = Constants.statusCodeOK;
                        resp.type = Constants.msgSuccess;
                        resp.message = Constants.dataHasBeenSaved;
                        resp.effectRow = objList.Count();
                        resp.data = "";

                    }

                    //if (updateList.Count != null && updateList.Count > 0)
                    //{
                    //    List<MasterDevice> objList = new List<MasterDevice>();

                    //    MasterDevice masterDevice = new MasterDevice();

                    //    MasterDeviceCategory masterDeviceCategory = new MasterDeviceCategory();

                    //    TcDevice tcDevice = new TcDevice();

                    //    MachineMaster machineMaster = new MachineMaster();

                    //    MachineModel machineModel = new MachineModel();

                    //    foreach (var item in updateList)
                    //    {
                    //        tcDevice = listData.Where(x => x.Uniqueid == item).FirstOrDefault();

                    //        machineMasters = machineMasters.Where(x => x.mcSerialNo != null).ToList();

                    //        machineMaster = machineMasters.Where(x => x.mcSerialNo.ToLower().Trim() == tcDevice.Uniqueid.ToLower().Trim()).FirstOrDefault();

                    //        machineMaster = machineMaster == null ? machineMasters.Where(x => x.mcChassis.Trim().ToLower() == tcDevice.Uniqueid.Trim().ToLower()).FirstOrDefault() : machineMaster;

                    //        if (machineMaster != null)
                    //        {
                    //            machineModel = machineModels.Where(x => x.machineModel1.ToLower().Trim() == machineMaster.mcModelGobal.ToLower().Trim()).FirstOrDefault();

                    //            if (machineModel != null)
                    //            {
                    //                masterDeviceCategory = masterDevicesCategory.Where(x => x.NameEn.ToLower().Trim() == machineModel.machineGroup.Trim().ToLower()).FirstOrDefault();
                    //            }
                    //            else
                    //            {
                    //                masterDeviceCategory = null;
                    //            }

                    //        }
                    //        else
                    //        {
                    //            masterDeviceCategory = null;
                    //        }

                    //        masterDevice = tempMasterDevices.Where(x => x.RefTrackingId == Convert.ToString(tcDevice.Uniqueid)).FirstOrDefault();

                    //        if (masterDevice != null)
                    //        {
                    //            masterDevice.SerialNo = machineMaster == null ? masterDevice.SerialNo : machineMaster.mcSerialNo == null ? masterDevice.SerialNo : machineMaster.mcSerialNo;
                    //            masterDevice.Chassis = machineMaster == null ? masterDevice.Chassis : machineMaster.mcChassis == null ? masterDevice.Chassis : machineMaster.mcChassis;

                    //            masterDevice.UpdateDate = DateTime.Now;
                    //            masterDevice.UpdateBy = "Interface";

                    //            objList.Add(masterDevice);
                    //        }
                    //    }

                    //    _context.MasterDevices.UpdateRange(objList);

                    //    _context.SaveChanges();
                    //}
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return resp;
        }
    }
}

