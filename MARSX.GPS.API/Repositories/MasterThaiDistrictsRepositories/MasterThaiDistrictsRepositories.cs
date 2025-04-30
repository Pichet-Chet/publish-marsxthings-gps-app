using System;
using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.PaginationModel;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services;
using System;
using MARSX.GPS.API.Services;
using WatchDog;

namespace MARSX.GPS.API.Repositories.MasterThaiDistrictsRepositories
{
	public class MasterThaiDistrictsRepositories : IMasterThaiDistrictsRepositories
    {
        private readonly TrackerContext _context;

        private readonly MasterThaiDistrictsService service;

        public MasterThaiDistrictsRepositories()
        {
            _context = new TrackerContext();

            service = new MasterThaiDistrictsService(_context);
        }

        public async Task<Response> Get(MasterThaiDistrictFilter param)
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
    }
}

