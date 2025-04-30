using System.Diagnostics;
using MARSX.GPS.API.Extension.Helper;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Customs;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Repositories.AuthenticationRepositories;
using Microsoft.AspNetCore.Mvc;
using WatchDog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepositories repoCollection;

        public AuthenticationController()
        {
            repoCollection = new AuthenticationRepositories();
        }

        // GET: api/values
        [HttpGet]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn([FromQuery] AuthorizationModel param)
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.AuthenticationSignIn(param));

                watch.Stop();

                result.responseTime = watch.Elapsed.TotalSeconds.ToString("N2") + " " + Constants.unitOfTime;
            }
            catch (Exception ex)
            {
                result.httpCode = Constants.httpCode500;
                result.status = Constants.statusError;
                result.statusCode = Constants.statusCodeException;
                result.message = Constants.httpCode500Message;
                result.exception = ex.Message;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return StatusCode(result.httpCode, AppHelper.GetResponseController(result));
        }

        [HttpGet]
        [Route("SignInWithPassCode")]
        public async Task<IActionResult> SignInWithPassCode([FromQuery] AuthorizationModel param)
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.AuthenticationSignInWithPassCode(param));

                watch.Stop();

                result.responseTime = watch.Elapsed.TotalSeconds.ToString("N2") + " " + Constants.unitOfTime;
            }
            catch (Exception ex)
            {
                result.httpCode = Constants.httpCode500;
                result.status = Constants.statusError;
                result.statusCode = Constants.statusCodeException;
                result.message = Constants.httpCode500Message;
                result.exception = ex.Message;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return StatusCode(result.httpCode, AppHelper.GetResponseController(result));
        }

        [HttpGet]
        [Route("AccountInformation")]
        public async Task<IActionResult> AccountInformation([FromQuery] AuthorizationModel param)
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.AuthenticationUserInformation(param));

                watch.Stop();

                result.responseTime = watch.Elapsed.TotalSeconds.ToString("N2") + " " + Constants.unitOfTime;
            }
            catch (Exception ex)
            {
                result.httpCode = Constants.httpCode500;
                result.status = Constants.statusError;
                result.statusCode = Constants.statusCodeException;
                result.message = Constants.httpCode500Message;
                result.exception = ex.Message;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return StatusCode(result.httpCode, AppHelper.GetResponseController(result));
        }
    }
}

