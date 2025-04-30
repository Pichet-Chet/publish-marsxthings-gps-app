using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace MARSX.GPS.API.Services
{
    public class MasterThaiProvincesService
	{
        private readonly TrackerContext _context;

        public MasterThaiProvincesService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> Get(MasterThaiProvincesFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            try
            {
                var queryable = await Task.Run(() => _context.MasterThaiProvinces.AsQueryable());

                #region Filter Data

                if (!string.IsNullOrWhiteSpace(param.textSearch))
                {
                    queryable = queryable.Where(x =>
                    x.NameEn.ToLower().Contains(param.textSearch.ToLower()) ||
                    x.NameTh.ToLower().Contains(param.textSearch.ToLower())
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

                List<MasterThaiProvince> execute = new List<MasterThaiProvince>();

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
    }
}

