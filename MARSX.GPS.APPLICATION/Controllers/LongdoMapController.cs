using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.LongdoMapRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class LongdoMapController : Controller
    {
        IConfiguration _configuration;

        private readonly ILongdoMapRepositories _repoCollection;

        public LongdoMapController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new LongdoMapRepositories(configuration);

        }

        // GET: /<controller>/
        public async Task<IActionResult> rerverseGeocoding(LongdoMapFilter param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => _repoCollection.rerverseGeocoding(param));
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

