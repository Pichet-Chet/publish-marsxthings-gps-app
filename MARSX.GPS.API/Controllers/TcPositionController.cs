using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.API.Extension.Helper;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Filters.TrackCar;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Repositories.SysUserRepositories;
using MARSX.GPS.API.Repositories.TcDevices;
using MARSX.GPS.API.Repositories.TcPositionRepositories;
using Microsoft.AspNetCore.Mvc;
using WatchDog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.API.Controllers
{
    [Route("api/[controller]")]
    public class TcPositionController : Controller
    {
        private readonly ITcPositionRepositories repoCollection;

        public TcPositionController()
        {
            repoCollection = new TcPositionRepositories();
        }

        [HttpGet]
        [Route("Get")]
        //[Authorize]
        public async Task<IActionResult> Get([FromQuery] PositionFilter param)
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.Get(param));

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
        [Route("ModelSerial")]
        //[Authorize]
        public async Task<IActionResult> ModelSerial([FromQuery] ModelSerialFilter param)
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.ModelSerial(param));

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

        //[HttpGet]
        //[Route("ModelSerialList")]
        ////[Authorize]
        //public async Task<IActionResult> ModelSerialList([FromBody] List<ModelSerialFilter> param)
        //{
        //    Response result = new Response();

        //    try
        //    {
        //        var watch = new Stopwatch();

        //        watch.Start();

        //        result = await Task.Run(() => repoCollection.ModelSerials(param));

        //        watch.Stop();

        //        result.responseTime = watch.Elapsed.TotalSeconds.ToString("N2") + " " + Constants.unitOfTime;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.httpCode = Constants.httpCode500;
        //        result.status = Constants.statusError;
        //        result.statusCode = Constants.statusCodeException;
        //        result.message = Constants.httpCode500Message;
        //        result.exception = ex.Message;
        //        WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
        //    }

        //    return StatusCode(result.httpCode, AppHelper.GetResponseController(result));

        //}


        [HttpGet]
        [Route("Serial")]
        public async Task<IActionResult> GetBySerial(string serial)
        {

            if (string.IsNullOrWhiteSpace(serial))
            {
                return BadRequest("Serial number is required.");
            }

            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.GetBySerial(serial));

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
        [Route("Serials")]
        public async Task<IActionResult> GetBySerials(List<string> serial)
        {
            Response result = new Response();

            if (serial == null || serial.Count <= 0)
            {
                return BadRequest("Serial number is required.");
            }

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.GetBySerials(serial));

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

