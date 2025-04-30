using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services;
using MARSX.GPS.API.Services.Logging;
using WatchDog;

namespace MARSX.GPS.API.Repositories.SysLogsApiRepositories
{
	public class SysLogApiRepositories : ISysLogApiRepositories
    {
        private readonly TrackerContext _context;

        private readonly LoggingAPIService service;

        public SysLogApiRepositories()
        {
            _context = new TrackerContext();

            service = new LoggingAPIService(_context);
        }

        public async Task<Response> Create(SysLogApi param)
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
    }
}

