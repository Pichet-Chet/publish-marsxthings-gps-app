using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Customs.MarsxTrack;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services.TransformData;
using Microsoft.EntityFrameworkCore;
using System;
using WatchDog;

namespace MARSX.GPS.API.Services
{
    public class MasterDeviceService
    {
        private readonly TrackerContext _context;

        private readonly MasterDeviceTransform tranformData;

        public MasterDeviceService(TrackerContext context)
        {
            _context = context;

            tranformData = new MasterDeviceTransform(context);
        }

        public async Task<Response> Get(MasterDeviceFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            try
            {
                var queryable = await Task.Run(() => _context.MasterDevices.AsQueryable());

                #region Filter Data

                if (param.Id != null && param.Id != 0)
                {
                    queryable = queryable.Where(x => x.Id == param.Id).AsQueryable();
                }
                else
                {
                    if (param.MasterGpsProviderId != null && param.MasterGpsProviderId != 0)

                    {
                        queryable = queryable.Where(x => x.MasterGpsProviderId == param.MasterGpsProviderId).AsQueryable();
                    }

                    if (param.MasterDeviceStatusId != null && param.MasterDeviceStatusId != 0)
                    {
                        queryable = queryable.Where(x => x.MasterDeviceStatusId == param.MasterDeviceStatusId).AsQueryable();
                    }

                    if (!string.IsNullOrEmpty(param.Model))
                    {
                        queryable = queryable.Where(x => x.Model == param.Model).AsQueryable();
                    }

                    if (!string.IsNullOrEmpty(param.RefTrackingId))
                    {
                        queryable = queryable.Where(x => x.RefTrackingId == param.RefTrackingId).AsQueryable();
                    }

                    if (!string.IsNullOrEmpty(param.Name))
                    {
                        queryable = queryable.Where(x => x.Name == param.Name).AsQueryable();
                    }

                    if (!string.IsNullOrEmpty(param.Phone))
                    {
                        queryable = queryable.Where(x => x.Phone == param.Phone).AsQueryable();
                    }

                    if (!string.IsNullOrEmpty(param.Contact))
                    {
                        queryable = queryable.Where(x => x.Contact == param.Contact).AsQueryable();
                    }


                    if (param.IsActive != null)
                    {
                        queryable = queryable.Where(x => x.IsActive == param.IsActive).AsQueryable();
                    }
                }

                //queryable = queryable.Where(x => x.MasterGpsProviderId == 2).AsQueryable();

                List<MasterDeviceViews> execute = new List<MasterDeviceViews>();

                List<MasterDevice> masterDevices = new List<MasterDevice>();


                masterDevices = queryable.AsNoTracking().ToList();

                masterDevices = masterDevices.OrderBy(x => x.Name).ToList();

                if (masterDevices.Count > 0)
                {
                    if (param.Id == null || param.Id == 0)
                    {
                        if (!string.IsNullOrEmpty(param.textSearch))
                        {
                            masterDevices = masterDevices.Where(x => x.Name != null).ToList();

                            masterDevices = masterDevices.Where(x => x.Name.Contains(param.textSearch)).ToList();
                        }
                    }

                    execute = await tranformData.Transform(masterDevices, param.Username);

                }

                if (!string.IsNullOrEmpty(param.TagAction))
                {
                    if (param.TagAction.ToLower() == Constants.tagActionDeviceAll.ToLower())
                    {
                        execute = execute;
                    }
                    else if (param.TagAction.ToLower() == Constants.tagActionDeviceGpsOnline.ToLower())
                    {
                        execute = execute.Where(x => x.GpsStatus != null).ToList();

                        execute = execute.Where(x => x.GpsStatus == "online").ToList();
                    }
                    else if (param.TagAction.ToLower() == Constants.tagActionDevicePowerOn.ToLower())
                    {
                        execute = execute.Where(x => x.TcAttributesView != null).ToList();

                        execute = execute.Where(x => x.TcAttributesView.ignition == true).ToList();
                    }
                    else
                    {

                    }
                }

                #endregion


                if (param.isAll != null)
                {
                    if (param.isAll == true)
                    {
                        execute = execute.ToList();
                    }
                    else
                    {
                        execute = execute
                       .Skip((param.PageNumber - 1) * param.PageSize)
                       .Take(param.PageSize)
                       .ToList();
                    }
                }
                else
                {
                    execute = execute
                   .Skip((param.PageNumber - 1) * param.PageSize)
                   .Take(param.PageSize)
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

                    resp.controller = "MasterDevice";
                    resp.method = "Get";
                    resp.service = "Get";
                }

                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.type = Constants.msgError;
                    resp.message = Constants.recordDataNotFound;

                    resp.controller = "MasterDevice";
                    resp.method = "Get";
                    resp.service = "Get";
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

        public async Task<Response> Detail(int id)
        {
            Response resp = new Response();

            MasterDevice objData = new MasterDevice();

            try
            {
                var queryable = await Task.Run(() => _context.MasterDevices.Where(x => x.Id == id).AsQueryable());

                var execute = queryable.AsNoTracking().FirstOrDefault();

                if (execute != null)
                {
                    objData = execute;

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
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
                resp.message = Constants.httpCode500Message;
                resp.type = Constants.msgError;
                resp.exception = ex.Message;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }
            return resp;
        }

        public async Task<Response> Create(MasterDevice param)
        {
            Response resp = new Response();

            try
            {
                var objDuplicate = await Task.Run(() => _context.MasterDevices.Where(x => x.MasterGpsProviderId == param.MasterGpsProviderId && x.RefTrackingId == param.RefTrackingId).FirstOrDefault());

                if (objDuplicate == null)
                {
                    param.CreateDate = DateTime.Now;
                    param.UpdateDate = DateTime.Now;

                    await _context.MasterDevices.AddAsync(param);

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
                var objUpdate = await Task.Run(() => _context.MasterDevices.Where(x => x.Id == param.Id).FirstOrDefault());

                if (objUpdate != null)
                {
                    var checkDuplicate = await Task.Run(() => _context.MasterDevices.Where(x => x.Id != param.Id && x.MasterGpsProviderId == param.MasterGpsProviderId && x.RefTrackingId == param.RefTrackingId).FirstOrDefault());

                    if (checkDuplicate == null)
                    {

                        objUpdate.Name = param.Name;
                        objUpdate.MasterDeviceGroupId = param.MasterDeviceGroupId;
                        objUpdate.MasterDeviceCategoryId = param.MasterDeviceCategoryId;
                        objUpdate.MasterDeviceStatusId = param.MasterDeviceStatusId;
                        objUpdate.Phone = param.Phone;
                        objUpdate.Model = param.Model;
                        objUpdate.Contact = param.Contact;
                        objUpdate.Description = param.Description;

                        objUpdate.IsActive = param.IsActive;
                        objUpdate.UpdateDate = DateTime.Now;
                        objUpdate.UpdateBy = param.UpdateBy;

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
                        resp.statusCode = Constants.statusCodeDataDuplicate;
                        resp.type = Constants.msgError;
                        resp.message = Constants.invalidDataDuplicate;
                    }
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

