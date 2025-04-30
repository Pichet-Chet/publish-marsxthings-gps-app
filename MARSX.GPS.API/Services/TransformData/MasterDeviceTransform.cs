using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Customs.MarsxTrack;
using MARSX.GPS.API.Models.Filters.LongdoMap;
using MARSX.GPS.API.Services.Extension;
using MARSX.GPS.API.Services.Extension.Longdo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MARSX.GPS.API.Services.TransformData
{
    public class MasterDeviceTransform
    {
        IConfigurationRoot config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

        private readonly TrackerContext _context;

        private readonly CarTrackService carTrackService;

        private readonly LongdoService longdoService;

        private string _domain = string.Empty;

        public MasterDeviceTransform(TrackerContext context)
        {
            _context = context;
            carTrackService = new CarTrackService(context);
            longdoService = new LongdoService(context);
        }

        public async Task<List<MasterDeviceViews>> Transform(List<MasterDevice> param,string username) // Additional models are imported from GlobalFilter and PaginationModel
        {
            List<MasterDeviceViews> result = new List<MasterDeviceViews>();

            List<SysDeviceFavorite> sysDeviceFavorites = new List<SysDeviceFavorite>();


            try
            {
                using (var context = new TrackerContext())
                {
                    sysDeviceFavorites = await Task.Run(() => _context.SysDeviceFavorites.AsNoTracking().ToList());

                    var tempMasterGpsProvider = await context.MasterGpsProviders.AsNoTracking().ToListAsync();


                    //var tempMasterGpsProvider = await _context.MasterGpsProviders.AsNoTracking().ToListAsync();
                    var tempMasterDeviceStatus = await context.MasterDeviceStatuses.AsNoTracking().ToListAsync();
                    var tempMasterDeviceGroup = await context.MasterDeviceGroups.AsNoTracking().ToListAsync();
                    var tempMasterDeviceCategory = await context.MasterDeviceCategories.AsNoTracking().ToListAsync();
                    //var tempMasterPhoto = await context.MasterPhotos.Where(x => x.Label != null).AsNoTracking().ToListAsync();

                    var tempTcDevice = await context.TcDevices.AsNoTracking().ToListAsync();

                    var tempTcPosition = await context.TcPositions
                                        //.OrderByDescending(tp => tp.Id)
                                        .GroupBy(tp => tp.Deviceid)
                                        .Select(group => group.OrderByDescending(x => x.Id).FirstOrDefault())
                                        .ToListAsync();

                    var tempVehiclesLatestStatusAll = await Task.Run(() => carTrackService.GetVehiclesLatestStatusAll());

                    tempVehiclesLatestStatusAll = tempVehiclesLatestStatusAll
                                                    //.OrderByDescending(tp => tp.vehicle_id)
                                                    .GroupBy(tp => tp.registration)
                                                    .Select(group => group.OrderByDescending(x => x.vehicle_id).FirstOrDefault()).ToList();


                    TagDevice tagDevice = new TagDevice();

                    tagDevice.tagCount = 0;
                    tagDevice.tagOnline = 0;
                    tagDevice.tagStart = 0;

                    Parallel.ForEach(param, item =>
                    {
                        MasterDeviceViews masterDeviceViews = new MasterDeviceViews();

                        var findMasterGpsProvider = item.MasterGpsProviderId == null ? null : tempMasterGpsProvider.Where(x => x.Id == item.MasterGpsProviderId).FirstOrDefault();
                        var findMasterDeviceStatus = item.MasterDeviceStatusId == null ? null : tempMasterDeviceStatus.Where(x => x.Id == item.MasterDeviceStatusId).FirstOrDefault();
                        var findMasterDeviceGroup = item.MasterDeviceGroupId == null ? null : tempMasterDeviceGroup.Where(x => x.Id == item.MasterDeviceGroupId).FirstOrDefault();
                        var findMasterDeviceCategory = item.MasterDeviceCategoryId == null ? null : tempMasterDeviceCategory.Where(x => x.Id == item.MasterDeviceCategoryId).FirstOrDefault();

                        //var getMasterPhotoDefault = tempMasterPhoto.Where(x => x.MasterDeviceId == item.Id && x.Label.ToUpper() == "FRONT").FirstOrDefault();

                        //var findMasterPhoto = getMasterPhotoDefault != null ? getMasterPhotoDefault.Location : tempMasterPhoto.Where(x => x.MasterDeviceId == item.Id).FirstOrDefault() != null ? tempMasterPhoto.Where(x => x.MasterDeviceId == item.Id).FirstOrDefault().Location : "";

                        if (item.MasterGpsProviderId == 1) // The provider gps is cartrack
                        {
                            var findVehiclesLatestStatusAll = tempVehiclesLatestStatusAll.Where(x => x.vehicle_id == Convert.ToInt32(item.RefTrackingId)).FirstOrDefault();

                            masterDeviceViews.Id = item.Id;
                            masterDeviceViews.MasterGpsProvider = findMasterGpsProvider == null ? null : findMasterGpsProvider;
                            masterDeviceViews.RefTrackingId = item.RefTrackingId;
                            masterDeviceViews.MasterDeviceStatus = findMasterDeviceStatus == null ? null : findMasterDeviceStatus;
                            masterDeviceViews.IsActive = item.IsActive;
                            masterDeviceViews.Name = item.Name;
                            masterDeviceViews.SerialNo = item.SerialNo;
                            masterDeviceViews.Chassis = item.Chassis;
                            masterDeviceViews.CarNo = item.CarNo;
                            masterDeviceViews.CompanyOwnerName = item.CompanyOwnerName;
                            masterDeviceViews.Model = item.Model;
                            masterDeviceViews.ModelYear = item.ModelYear;
                            masterDeviceViews.Manufacturer = item.Manufacturer;
                            masterDeviceViews.Phone = item.Phone;
                            masterDeviceViews.Contact = item.Contact;
                            masterDeviceViews.MasterDeviceGroup = findMasterDeviceGroup == null ? null : findMasterDeviceGroup;
                            masterDeviceViews.MasterDeviceCategory = findMasterDeviceCategory == null ? null : findMasterDeviceCategory;
                            masterDeviceViews.Description = item.Description;

                            masterDeviceViews.Lat = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.location_latitude;
                            masterDeviceViews.Lon = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.location_longitude;
                            masterDeviceViews.Address = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.location_position_description;
                            //masterDeviceViews.PhotoPath = findMasterPhoto;


                            TcAttributesView tcAttributesView = new TcAttributesView();
                            tcAttributesView.ignition = findVehiclesLatestStatusAll == null ? false : findVehiclesLatestStatusAll.ignition;
                            tcAttributesView.fuel = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.fuel_precentage_left;
                            tcAttributesView.fuelLevel = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.fuel_level;
                            tcAttributesView.odometer = findVehiclesLatestStatusAll == null ? null : (findVehiclesLatestStatusAll.odometer / 1000);
                            tcAttributesView.totalDistance = findVehiclesLatestStatusAll == null ? null : (findVehiclesLatestStatusAll.odometer / 1000);
                            tcAttributesView.hours = findVehiclesLatestStatusAll == null ? null : (findVehiclesLatestStatusAll.clock / 3600);
                            tcAttributesView.speed = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.speed;

                            tcAttributesView.serverTime = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.location_updated == null ? null : findVehiclesLatestStatusAll.location_updated;
                            tcAttributesView.deviceTime = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.location_updated == null ? null : findVehiclesLatestStatusAll.location_updated;
                            tcAttributesView.fixTime = findVehiclesLatestStatusAll == null ? null : findVehiclesLatestStatusAll.location_updated == null ? null : findVehiclesLatestStatusAll.location_updated;


                            masterDeviceViews.GpsStatus = findVehiclesLatestStatusAll == null ? "offline" : findVehiclesLatestStatusAll.ignition == null ? "offline" : findVehiclesLatestStatusAll.ignition == false ? "offline" : "online";


                            tagDevice.tagCount++;

                            if (masterDeviceViews.GpsStatus != null)
                            {
                                if (masterDeviceViews.GpsStatus.ToLower() == "online")
                                {
                                    tagDevice.tagOnline++;
                                }
                            }

                            if (tcAttributesView.ignition != null)
                            {
                                if (tcAttributesView.ignition == true)
                                {
                                    tagDevice.tagStart++;
                                }
                            }

                            masterDeviceViews.TcAttributesView = tcAttributesView;

                            result.Add(masterDeviceViews);
                        }
                        else if (item.MasterGpsProviderId == 2) // The provider gps is Tc
                        {
                            var findTcDevice = tempTcDevice.Where(x => x.Uniqueid == item.RefTrackingId).FirstOrDefault();

                            var findTcPositionLast = findTcDevice == null ? null : tempTcPosition.Where(x => x.Deviceid == findTcDevice.Id).OrderByDescending(x => x.Id).FirstOrDefault();

                            masterDeviceViews.Id = item.Id;
                            masterDeviceViews.MasterGpsProvider = findMasterGpsProvider == null ? null : findMasterGpsProvider;
                            masterDeviceViews.RefTrackingId = item.RefTrackingId;
                            masterDeviceViews.MasterDeviceStatus = findMasterDeviceStatus == null ? null : findMasterDeviceStatus;
                            masterDeviceViews.IsActive = item.IsActive;
                            masterDeviceViews.Name = item.Name;
                            masterDeviceViews.Model = item.Model;
                            masterDeviceViews.SerialNo = item.SerialNo;
                            masterDeviceViews.Chassis = item.Chassis;
                            masterDeviceViews.CarNo = item.CarNo;
                            masterDeviceViews.CompanyOwnerName = item.CompanyOwnerName;
                            masterDeviceViews.Phone = item.Phone;
                            masterDeviceViews.Contact = item.Contact;
                            masterDeviceViews.MasterDeviceGroup = findMasterDeviceGroup == null ? null : findMasterDeviceGroup;
                            masterDeviceViews.MasterDeviceCategory = findMasterDeviceCategory == null ? null : findMasterDeviceCategory;
                            masterDeviceViews.Description = item.Description;
                            masterDeviceViews.Lat = findTcPositionLast == null ? null : findTcPositionLast.Latitude;
                            masterDeviceViews.Lon = findTcPositionLast == null ? null : findTcPositionLast.Longitude;

                            if (masterDeviceViews.Lat != null && masterDeviceViews.Lon != null)
                            {
                                LongdoMapFilter longdoMapFilter = new LongdoMapFilter();

                                longdoMapFilter.lat = masterDeviceViews.Lat;
                                longdoMapFilter.lon = masterDeviceViews.Lon;

                                var currentAddress = longdoService.rerverseGeocoding(longdoMapFilter).Result;

                                masterDeviceViews.Address = currentAddress;
                            }

                            masterDeviceViews.GpsStatus = findTcDevice == null ? "unknown" : findTcDevice.Status == null ? "" : findTcDevice.Status.Trim();


                            if (findTcPositionLast != null)
                            {
                                if (!string.IsNullOrEmpty(findTcPositionLast.Attributes) || findTcPositionLast.Attributes != "{}")
                                {
                                    masterDeviceViews.TcAttributesView = JsonConvert.DeserializeObject<TcAttributesView>(findTcPositionLast.Attributes);

                                    masterDeviceViews.TcAttributesView.serverTime = findTcPositionLast == null ? null : findTcPositionLast.Servertime == null ? null : findTcPositionLast.Servertime;
                                    masterDeviceViews.TcAttributesView.deviceTime = findTcPositionLast == null ? null : findTcPositionLast.Devicetime == null ? null : findTcPositionLast.Devicetime;
                                    masterDeviceViews.TcAttributesView.fixTime = findTcPositionLast == null ? null : findTcPositionLast.Fixtime == null ? null : findTcPositionLast.Fixtime;

                                    masterDeviceViews.TcAttributesView.totalDistance = masterDeviceViews.TcAttributesView.totalDistance == null ? null : Convert.ToDouble(Math.Round(Convert.ToDecimal(masterDeviceViews.TcAttributesView.totalDistance), 2));
                                    masterDeviceViews.TcAttributesView.fuel = masterDeviceViews.TcAttributesView.fuel == null ? null : Convert.ToDouble(Math.Round(Convert.ToDecimal(masterDeviceViews.TcAttributesView.fuel), 2));
                                    masterDeviceViews.TcAttributesView.power = masterDeviceViews.TcAttributesView.power == null ? null : Convert.ToDouble(Math.Round(Convert.ToDecimal(masterDeviceViews.TcAttributesView.power), 3));



                                    if (masterDeviceViews.TcAttributesView != null)
                                    {
                                        if (masterDeviceViews.TcAttributesView.ignition == true)
                                        {
                                            tagDevice.tagStart++;
                                        }

                                        if (masterDeviceViews.TcAttributesView.hours >= 0)
                                        {
                                            masterDeviceViews.TcAttributesView.hours = masterDeviceViews.TcAttributesView.hours / 1000 / 60 / 60;
                                        }
                                    }

                                }
                            }

                            tagDevice.tagCount++;

                            if (masterDeviceViews.GpsStatus != null)
                            {
                                if (masterDeviceViews.GpsStatus.ToLower() == "online")
                                {
                                    tagDevice.tagOnline++;
                                }
                            }
                            result.Add(masterDeviceViews);
                        }

                        if (!string.IsNullOrEmpty(username))
                        {
                            masterDeviceViews.isFavorite = item.Id == null ? false : sysDeviceFavorites == null ? false : sysDeviceFavorites.Count <= 0 ? false : sysDeviceFavorites.Where(x => x.DeviceId == item.Id && x.UserName.ToLower() == username.ToLower()).Any();
                        }

                    });

                    if (result.Count > 0)
                    {
                        result.ForEach(x => x.TagDevice = tagDevice);
                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }

            return result.OrderBy(x => x.Name).ToList();
        }
    }
}

