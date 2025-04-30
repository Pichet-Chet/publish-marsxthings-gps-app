using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.TcSessionRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    [Route("api/[controller]")]
    public class TcSessionController : Controller
    {
        IConfiguration _configuration;

        private readonly ITcSessionRepositories _repoCollection;

        public TcSessionController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new TcSessionRepositories(configuration);

        }

        // GET: /<controller>/
        public async Task<IActionResult> Create()
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => _repoCollection.Create());
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

