using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services;
using WatchDog;

namespace MARSX.GPS.API.Repositories.MasterDeviceCategoryRepositories
{
	public class MasterDeviceCategoryRepositories : IMasterDeviceCategoryRepositories
    {
        private readonly TrackerContext _context;

        private readonly MasterDeviceCategoryService service;

        public MasterDeviceCategoryRepositories()
        {
            _context = new TrackerContext();

            service = new MasterDeviceCategoryService(_context);
        }

        public async Task<Response> Get(MasterDeviceCategoryFilter param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.Get(param));
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

            try
            {
                resp = await Task.Run(() => service.Detail(id));
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

        public async Task<Response> Create(MasterDeviceCategory param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.Create(param));
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

        public async Task<Response> Update(MasterDeviceCategory param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.Update(param));
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

