using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.TcDevicesRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class TcDevicesController : Controller
    {
        IConfiguration _configuration;

        private readonly ITcDevicesRepositories _repoCollection;

        public TcDevicesController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new TcDevicesRepositories(configuration);

        }

        // GET: /<controller>/
        public async Task<IActionResult> Get(DevicesFilter param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => _repoCollection.Get(param));
            }
            catch (Exception ex)
            {
                resp.status = false;
                resp.exception = ex.Message;
            }

            return new JsonResult(resp);
        }
    }
}

