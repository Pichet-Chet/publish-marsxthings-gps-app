using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Microsoft.AspNetCore.Mvc;
using MARSX.GPS.APPLICATION.Repositories.TcPositionRepositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class TcPostionController : Controller
    {
        IConfiguration _configuration;

        private readonly ITcPositionRepositories _repoCollection;

        public TcPostionController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new TcPositionRepositories(configuration);

        }

        // GET: /<controller>/
        public async Task<IActionResult> Get(PositionFilter param)
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

