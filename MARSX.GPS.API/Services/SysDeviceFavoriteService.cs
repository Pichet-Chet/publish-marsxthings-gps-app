using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using System;
using WatchDog;

namespace MARSX.GPS.API.Services
{
	public class SysDeviceFavoriteService
    {
        private readonly TrackerContext _context;

        public SysDeviceFavoriteService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> Get(SysDeviceFavoriteFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            try
            {
                var queryable = await Task.Run(() => _context.SysDeviceFavorites.AsQueryable());

                #region Filter Data

               
                if (param.DeviceId != null)
                {
                    queryable = queryable.Where(x => x.DeviceId == param.DeviceId).AsQueryable();
                }

                if (param.UserId != null)
                {
                    queryable = queryable.Where(x => x.UserName == param.UserName).AsQueryable();
                }


                List<SysDeviceFavorite> execute = new List<SysDeviceFavorite>();

                execute = queryable.AsNoTracking().ToList();

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

        public async Task<Response> Detail(int id)
        {
            Response resp = new Response();

            SysDeviceFavorite objData = new SysDeviceFavorite();

            try
            {
                var queryable = await Task.Run(() => _context.SysDeviceFavorites.Where(x => x.Id == id).AsQueryable());

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

        public async Task<Response> Create(SysDeviceFavorite param)
        {
            Response resp = new Response();

            try
            {
                var objDuplicate = await Task.Run(() => _context.SysDeviceFavorites.Where(x => x.DeviceId == param.DeviceId && x.UserName.ToLower() == param.UserName.ToLower()).FirstOrDefault());

                if (objDuplicate == null)
                {
                    param.CreateDate = DateTime.Now;
                    param.UpdateDate = DateTime.Now;
                    param.UserName = param.CreateBy;

                    await _context.SysDeviceFavorites.AddAsync(param);

                    _context.SaveChanges();

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.effectRow = 1;
                    resp.data = param;
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeException;
                    resp.message = Constants.invalidDataDuplicate;
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

        public async Task<Response> Update(SysDeviceFavorite param)
        {
            Response resp = new Response();

            try
            {
                var objUpdate = await Task.Run(() => _context.SysDeviceFavorites.Where(x => x.Id == param.Id).FirstOrDefault());

                if (objUpdate != null)
                {
                    var checkDuplicate = await Task.Run(() => _context.SysDeviceFavorites.Where(x => x.DeviceId == param.DeviceId && x.UserName == param.UserName).FirstOrDefault());

                    if (checkDuplicate == null)
                    {
                        objUpdate.DeviceId = param.DeviceId;
                        objUpdate.UserName = param.UserName;

                        objUpdate.UpdateDate = DateTime.Now;
                        objUpdate.UpdateBy = param.UpdateBy;
                    }
                    else
                    {
                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusError;
                        resp.statusCode = Constants.statusCodeDataDuplicate;
                        resp.message = Constants.invalidDataDuplicate;
                    }
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.recordDataNotFound;
                }

                await Task.Run(() => _context.SysDeviceFavorites.Update(param));

                resp.httpCode = Constants.httpCode200;
                resp.status = Constants.statusSuccess;
                resp.statusCode = Constants.statusCodeOK;
                resp.effectRow = 1;
                resp.data = param;
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

        public async Task<Response> Delete(SysDeviceFavorite param)
        {
            Response resp = new Response();

            try
            {
                var objUpdate = await Task.Run(() => _context.SysDeviceFavorites.Where(x => x.DeviceId == param.DeviceId && x.UserName.ToLower() == param.UserName.ToLower()).FirstOrDefault());

                if (objUpdate != null)
                {
                    await Task.Run(() => _context.SysDeviceFavorites.Remove(objUpdate));

                    _context.SaveChanges();
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.recordDataNotFound;
                }

                resp.httpCode = Constants.httpCode200;
                resp.status = Constants.statusSuccess;
                resp.statusCode = Constants.statusCodeOK;
                resp.effectRow = 1;
                resp.data = param;
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
    }
}

