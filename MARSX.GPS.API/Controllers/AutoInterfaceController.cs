using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.API.Extension.Helper;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Repositories.AutoInterfaceRepositories;
using Microsoft.AspNetCore.Mvc;
using WatchDog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoInterfaceController : ControllerBase
    {
        private readonly IAutoInterfaceRepositories repoCollection;

        public AutoInterfaceController()
        {
            repoCollection = new AutoInterfaceRepositories();
        }

        #region CarTrack Interface
        
        [HttpGet]
        [Route("SyncDeviceFromCarTrackService")]
        //[Authorize]
        public async Task<IActionResult> SyncDeviceFromCarTrackService()
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.SyncDeviceFromCarTrackService());

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

        #endregion


        #region Tc Interface

        [HttpGet]
        [Route("SyncDeviceFromTcService")]
        //[Authorize]
        public async Task<IActionResult> SyncDeviceFromTcService()
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.SyncDeviceFromTcService());

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

        #endregion

    }
}

