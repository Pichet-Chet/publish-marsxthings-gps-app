using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services;
using MARSX.GPS.API.Services.Extension;
using WatchDog;

namespace MARSX.GPS.API.Repositories.AutoInterfaceRepositories
{
	public class AutoInterfaceRepositories : IAutoInterfaceRepositories
    {

        private readonly TrackerContext _context;

        private readonly CarTrackService carTrackService;

        private readonly TcService tcService;

        public AutoInterfaceRepositories()
        {
            _context = new TrackerContext();

            carTrackService = new CarTrackService(_context);

            tcService = new TcService(_context);
        }
        

        public async Task<Response> SyncDeviceFromCarTrackService()
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => carTrackService.SyncDevice());
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


        public async Task<Response> SyncDeviceFromTcService()
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => tcService.SyncDevice());
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

