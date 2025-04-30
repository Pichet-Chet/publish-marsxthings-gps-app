using System;
using MARSX.GPS.API.Extension.Mapping.TracCar;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Filters.TrackCar;
using MARSX.GPS.API.Models.Customs.MarsxTrack;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WatchDog;

namespace MARSX.GPS.API.Services
{
    public class TcDevicesService
    {
        private readonly TrackerContext _context;

        public TcDevicesService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> Get(DevicesFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            try
            {

                var queryable = await Task.Run(() => _context.TcDevices.AsQueryable());

                var queryablePosition = await Task.Run(() => _context.TcPositions.AsQueryable());

                #region Filter Data

                if (param.id != null)
                {
                    queryable = queryable.Where(x => x.Id == param.id).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.name))
                {
                    queryable = queryable.Where(x => x.Name.ToLower().Contains(param.name.ToLower())).AsQueryable();
                }

                var dto = queryable.AsNoTracking().ToList();

                foreach (var item in dto)
                {
                    var queryableAttibute = queryablePosition.Where(x => x.Deviceid == item.Id).OrderByDescending(x => x.Id).AsQueryable();

                    item.Attributes = queryableAttibute.Select(x => x.Attributes).LastOrDefault();
                }


                List<TcDevicesView> execute = new List<TcDevicesView>();

                execute = TcDeviceMapping.devices(dto);

                foreach (var item in execute)
                {
                    var executePosition = queryablePosition.Where(x => x.Deviceid == item.id).OrderByDescending(x => x.Id).FirstOrDefault();

                    if (executePosition != null)
                    {
                        item.lat = executePosition.Latitude;
                        item.lon = executePosition.Longitude;
                    }
                }

                #endregion


                if (param.isAll != null)
                {
                    if (param.isAll == true)
                    {
                        execute = execute.OrderBy(x => x.name).ToList();
                    }
                    else
                    {
                        execute = execute
                       .Skip((param.PageNumber - 1) * param.PageSize)
                       .Take(param.PageSize)
                       .OrderBy(x => x.name)
                       .ToList();
                    }
                }
                else
                {
                    execute = execute
                   .Skip((param.PageNumber - 1) * param.PageSize)
                   .Take(param.PageSize)
                   .OrderBy(x => x.name)
                   .ToList();
                }

                if (execute != null && execute.Count > 0)
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.data = execute;

                    resp.pageNumber = param.PageNumber;
                    resp.pageSize = param.PageSize;
                    resp.effectRow = execute.Count();
                }

                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.recordDataNotFound;
                }


            }
            catch (Exception ex)
            {
                resp.httpCode = Constants.httpCode500;
                resp.status = Constants.statusError;
                resp.statusCode = Constants.statusCodeException;
                resp.message = Constants.httpCode500Message;
                resp.exception = ex.Message;
                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return resp;
        }

        public async Task<List<TcDevice>> DevicesByModel(string model)
        {
            List<TcDevice> tcDevices = new List<TcDevice>();
            try
            {
                tcDevices = await _context.TcDevices.Where(x => (x.Model == null ? "" : x.Model.ToLower()) == model.ToLower()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tcDevices;
        }
        public async Task<List<TcDevice>> DevicesByGroup(int id)
        {
            List<TcDevice> tcDevices = new List<TcDevice>();
            try
            {
                tcDevices = await _context.TcDevices.Where(x => x.Groupid == id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tcDevices;
        }

        public async Task<Response> Create(MasterDevice param)
        {
            Response resp = new Response();

            try
            {
                var objDuplicate = await Task.Run(() => _context.TcDevices.Where(x => x.Uniqueid == param.RefTrackingId).FirstOrDefault());

                if (objDuplicate == null)
                {
                    TcDevice tcDevice = new TcDevice();


                    var findCategoryName = await Task.Run(() => _context.MasterDeviceCategories.Where(x => x.Id == param.MasterDeviceCategoryId).FirstOrDefault());
                    var findStatusName = await Task.Run(() => _context.MasterDeviceStatuses.Where(x => x.Id == param.MasterDeviceStatusId).FirstOrDefault());


                    tcDevice.Name = param.Name;
                    tcDevice.Uniqueid = param.RefTrackingId;
                    tcDevice.Lastupdate = null;
                    tcDevice.Positionid = null;
                    tcDevice.Groupid = param.MasterDeviceGroupId;
                    tcDevice.Attributes = "{}";
                    tcDevice.Phone = param.Phone;
                    tcDevice.Model = param.Model;
                    tcDevice.Contact = param.Contact;


                    tcDevice.Category = findCategoryName == null ? null : findCategoryName.NameEn.ToLower();
                    tcDevice.Disabled = false;
                    tcDevice.Status = findStatusName == null ? null : findStatusName.NameEn.ToLower();
                    tcDevice.Expirationtime = null;
                    tcDevice.Motionstate = false;
                    tcDevice.Motiontime = null;
                    tcDevice.Motiondistance = null;
                    tcDevice.Overspeedstate = false;
                    tcDevice.Overspeedtime = null;
                    tcDevice.Overspeedgeofenceid = 0;
                    tcDevice.Motionstreak = false;
                    tcDevice.Calendarid = null;

                    await _context.TcDevices.AddAsync(tcDevice);

                    _context.SaveChanges();

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.type = Constants.msgSuccess;
                    resp.message = Constants.dataHasBeenSaved;
                    resp.effectRow = 1;
                    resp.data = param;
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeException;
                    resp.type = Constants.msgError;
                    resp.message = Constants.invalidDataDuplicate;
                }
            }
            catch (Exception ex)
            {
                resp.httpCode = Constants.httpCode500;
                resp.status = Constants.statusError;
                resp.statusCode = Constants.statusCodeException;
                resp.type = Constants.msgError;
                resp.message = Constants.httpCode500Message;
                resp.exception = ex.Message;
                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }
            return resp;
        }


        public async Task<Response> Update(MasterDevice param)
        {
            Response resp = new Response();

            try
            {
                var objUpdate = await Task.Run(() => _context.TcDevices.Where(x => x.Uniqueid == param.RefTrackingId).FirstOrDefault());

                if (objUpdate != null)
                {
                    objUpdate.Name = param == null ? objUpdate.Name : param.Name == null ? objUpdate.Name : param.Name;
                    objUpdate.Phone = param == null ? objUpdate.Phone : param.Phone == null ? objUpdate.Phone : param.Phone;
                    objUpdate.Model = param == null ? objUpdate.Model : param.Model == null ? objUpdate.Model : param.Model;
                    objUpdate.Contact = param == null ? objUpdate.Contact : param.Contact == null ? objUpdate.Contact : param.Contact;

                    await _context.SaveChangesAsync();

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.type = Constants.msgSuccess;
                    resp.message = Constants.dataHasBeenSaved;
                    resp.effectRow = 1;
                    resp.data = param;
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeException;
                    resp.type = Constants.msgError;
                    resp.message = Constants.invalidDataDuplicate;
                }
            }
            catch (Exception ex)
            {
                resp.httpCode = Constants.httpCode500;
                resp.status = Constants.statusError;
                resp.statusCode = Constants.statusCodeException;
                resp.type = Constants.msgError;
                resp.message = Constants.httpCode500Message;
                resp.exception = ex.Message;
                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }
            return resp;
        }


        public async Task<Response> Delete(MasterDevice param)
        {
            Response resp = new Response();

            TcDevice objData = new TcDevice();

            try
            {
                var queryable = await Task.Run(() => _context.TcDevices.Where(x => x.Id == param.Id).AsQueryable());

                var execute = queryable.AsNoTracking().FirstOrDefault();

                if (execute != null)
                {
                    _context.TcDevices.Remove(execute);

                    _context.SaveChanges();

                    objData = execute;

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.type = Constants.msgSuccess;
                    resp.message = Constants.dataHasBeenSaved;
                    resp.effectRow = 1;
                    resp.data = objData;
                }

                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.type = Constants.msgError;
                    resp.message = Constants.recordDataNotFound;
                }
            }
            catch (Exception ex)
            {
                resp.httpCode = Constants.httpCode500;
                resp.status = Constants.statusError;
                resp.statusCode = Constants.statusCodeException;
                resp.type = Constants.msgError;
                resp.message = Constants.httpCode500Message;
                resp.exception = ex.Message;
                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }
            return resp;
        }


    }
}

