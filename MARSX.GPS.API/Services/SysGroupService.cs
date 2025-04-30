using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using System;
using WatchDog;

namespace MARSX.GPS.API.Services
{
    public class SysGroupService
    {
        private readonly TrackerContext _context;

        public SysGroupService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> Get(SysGroupFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            try
            {
                var queryable = await Task.Run(() => _context.SysGroups.AsQueryable());

                #region Filter Data

                if (!string.IsNullOrWhiteSpace(param.textSearch))
                {
                    queryable = queryable.Where(x =>
                    x.NameEn.ToLower().Contains(param.textSearch.ToLower()) ||
                    x.NameTh.ToLower().Contains(param.textSearch.ToLower()) ||
                    x.Description.ToLower().Contains(param.textSearch.ToLower())
                    ).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.NameEn))
                {
                    queryable = queryable.Where(x => x.NameEn.ToLower().Contains(param.NameEn.ToLower())).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.NameTh))
                {
                    queryable = queryable.Where(x => x.NameTh.ToLower().Contains(param.NameTh.ToLower())).AsQueryable();
                }

                if (param.IsActive != null)
                {
                    queryable = queryable.Where(x => x.IsActive == param.IsActive).AsQueryable();
                }


                List<SysGroup> execute = new List<SysGroup>();

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

            SysGroup objData = new SysGroup();

            try
            {
                var queryable = await Task.Run(() => _context.SysGroups.Where(x => x.Id == id).AsQueryable());

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

        public async Task<Response> Create(SysGroup param)
        {
            Response resp = new Response();

            try
            {
                var objDuplicate = await Task.Run(() => _context.SysGroups.Where(x => x.NameEn == param.NameEn && x.NameTh == param.NameTh).FirstOrDefault());

                if (objDuplicate == null)
                {
                    param.CreateDate = DateTime.Now;
                    param.UpdateDate = DateTime.Now;

                    await _context.SysGroups.AddAsync(param);

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

        public async Task<Response> Update(SysGroup param)
        {
            Response resp = new Response();

            try
            {
                var objUpdate = await Task.Run(() => _context.SysGroups.Where(x => x.Id == param.Id).FirstOrDefault());

                if (objUpdate != null)
                {
                    var checkDuplicate = await Task.Run(() => _context.SysGroups.Where(x => x.NameEn == param.NameEn && x.NameTh == param.NameTh).FirstOrDefault());

                    if (checkDuplicate == null)
                    {
                        objUpdate.NameEn = param.NameEn;
                        objUpdate.NameTh = param.NameTh;
                        objUpdate.Description = param.Description;
                        objUpdate.IsActive = param.IsActive;

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

                await Task.Run(() => _context.SysGroups.Update(param));

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

