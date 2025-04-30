using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace MARSX.GPS.API.Services
{
    public class SysUserService
    {
        private readonly TrackerContext _context;

        public SysUserService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> Get(SysUserFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            try
            {
                var queryable = await Task.Run(() => _context.SysUsers.AsQueryable());

                #region Filter Data

                if (!string.IsNullOrWhiteSpace(param.textSearch))
                {
                    queryable = queryable.Where(x =>
                    x.UserName.ToLower().Contains(param.textSearch.ToLower()) ||
                    x.FirstNameEn.ToLower().Contains(param.textSearch.ToLower()) ||
                    x.LastNameEn.ToLower().Contains(param.textSearch.ToLower()) ||
                    x.FirstNameTh.ToLower().Contains(param.textSearch.ToLower()) ||
                    x.LastNameTh.ToLower().Contains(param.textSearch.ToLower())
                    ).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.UserName))
                {
                    queryable = queryable.Where(x => x.UserName.ToLower().Contains(param.UserName.ToLower())).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.FirstNameEn))
                {
                    queryable = queryable.Where(x => x.FirstNameEn.ToLower().Contains(param.FirstNameEn.ToLower())).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.LastNameEn))
                {
                    queryable = queryable.Where(x => x.LastNameEn.ToLower().Contains(param.LastNameEn.ToLower())).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.FirstNameTh))
                {
                    queryable = queryable.Where(x => x.FirstNameTh.ToLower().Contains(param.FirstNameTh.ToLower())).AsQueryable();
                }

                if (!string.IsNullOrEmpty(param.LastNameTh))
                {
                    queryable = queryable.Where(x => x.LastNameTh.ToLower().Contains(param.LastNameTh.ToLower())).AsQueryable();
                }

                //Type type = param.GetType();

                //foreach (PropertyInfo property in type.GetProperties())
                //{
                //    if (property.GetValue(param) != null)
                //    {
                //        var columnName = AppHelper.FirstCharToLowerCase(property.Name);

                //        var valueFilter = property.GetValue(param);

                //        //queryable = queryable.Where(x => Sql.Property<object>(x, columnName) == valueFilter).AsQueryable();

                //        //queryable = queryable.Where(x => x.GetType().GetProperty(columnName).GetValue(x) == property.GetValue(param)).AsQueryable();

                //        //queryable = queryable.Where(x => x.GetType().GetProperty(AppHelper.FirstCharToLowerCase(property.Name)).PropertyType == property.GetValue(param)).AsQueryable();
                //    }
                //}

                List<SysUser> execute = new List<SysUser>();

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

            SysUser objData = new SysUser();

            try
            {
                var queryable = await Task.Run(() => _context.SysUsers.Where(x => x.Id == id).AsQueryable());

                var execute = queryable.AsNoTracking().FirstOrDefault();

                if (execute != null)
                {
                    objData = execute;

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
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

        public async Task<Response> Create(SysUser param)
        {
            Response resp = new Response();

            try
            {
                var objDuplicate = await Task.Run(() => _context.SysUsers.Where(x => x.UserName == param.UserName || x.Email == param.Email).FirstOrDefault());

                if (objDuplicate != null)
                {
                    param.CreateDate = DateTime.UtcNow;
                    param.UpdateDate = DateTime.UtcNow;
                    //param.Password = AppHelper.HashPassword(param.Password);

                    await Task.Run(() => _context.SysUsers.AddAsync(param));

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
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

        public async Task<Response> Update(SysUser param)
        {
            Response resp = new Response();

            try
            {
                var objUpdate = await Task.Run(() => _context.SysUsers.Where(x => x.Id == param.Id).FirstOrDefault());

                if (objUpdate != null)
                {
                    objUpdate.FirstNameEn = param.FirstNameEn;
                    objUpdate.LastNameEn = param.LastNameEn;
                    objUpdate.FirstNameTh = param.FirstNameTh;
                    objUpdate.LastNameTh = param.LastNameTh;
                    objUpdate.Age = param.Age;
                    objUpdate.Gender = param.Gender;
                    objUpdate.MasterCompanyId = param.MasterCompanyId;
                    objUpdate.MasterDepartmentId = param.MasterDepartmentId;
                    objUpdate.MasterPositionId = param.MasterPositionId;
                    objUpdate.IsActive = param.IsActive;
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.recordDataNotFound;
                }

                await Task.Run(() => _context.SysUsers.Update(param));

                resp.httpCode = Constants.httpCode200;
                resp.status = Constants.statusSuccess;
                resp.statusCode = Constants.statusCodeOK;
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

        public async Task<Response> UpdatePassCode(SysUser param)
        {
            Response resp = new Response();

            try
            {
                var objUpdate = await Task.Run(() => _context.SysUsers.Where(x => x.Id == param.Id).FirstOrDefault());

                if (objUpdate != null)
                {
                    objUpdate.PassCode = param.PassCode;
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.recordDataNotFound;
                }

                _context.SysUsers.Update(objUpdate);

                await _context.SaveChangesAsync();

                resp.httpCode = Constants.httpCode200;
                resp.status = Constants.statusSuccess;
                resp.statusCode = Constants.statusCodeOK;
                resp.data = objUpdate;
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

