using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Customs;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services;
using WatchDog;

namespace MARSX.GPS.API.Repositories.AuthenticationRepositories
{
	public class AuthenticationRepositories : IAuthenticationRepositories
    {
        private readonly TrackerContext _context;

        private readonly AuthenticationService service;

        public AuthenticationRepositories()
        {
            _context = new TrackerContext();

            service = new AuthenticationService(_context);
        }

        public async Task<Response> AuthenticationSignIn(AuthorizationModel param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.AuthenticationSignIn(param));
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

        public async Task<Response> AuthenticationSignInWithPassCode(AuthorizationModel param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.AuthenticationSignInWithPassCode(param));
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

        public async Task<Response> AuthenticationUserInformation(AuthorizationModel param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.AuthenticationUserInformation(param));
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

