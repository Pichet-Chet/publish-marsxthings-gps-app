using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Customs;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace MARSX.GPS.API.Repositories.AuthorizationRepositories
{
	public class AuthorizationRepositories : IAuthorizationRepositories
    {
        private readonly TrackerContext _context;

        private readonly AuthorizationService service;

        public AuthorizationRepositories()
        {
            _context = new TrackerContext();

            service = new AuthorizationService(_context);
        }

        public async Task<Response> GenerateToken(AuthorizationModel param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.GenerateToken(param));
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

