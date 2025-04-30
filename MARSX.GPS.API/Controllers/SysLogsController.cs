using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.API.Extension.Helper;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Repositories.SysLogsRepositories;
using MARSX.GPS.API.Repositories.SysUserRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchDog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysLogsController : ControllerBase
    {
        private readonly ISysLogsRepositories repoCollection;

        public SysLogsController()
        {
            repoCollection = new SysLogsRepositories();
        }

        [HttpPost]
        [Route("Create")]
        //[Authorize]
        public async Task<IActionResult> Create([FromBody] SysLog param)
        {
            Response result = new Response();

            try
            {
                var watch = new Stopwatch();

                watch.Start();

                result = await Task.Run(() => repoCollection.Create(param));

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

