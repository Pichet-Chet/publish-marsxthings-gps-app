using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Customs;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.MasterDeviceStatusRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class MasterDeviceStatusController : Controller
    {
        IConfiguration _configuration;

        private readonly IMasterDeviceStatusRepositories _repoCollection;

        public MasterDeviceStatusController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new MasterDeviceStatusRepositories(configuration);

        }

        public IActionResult Index()
        {
            UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

            if (userInfo == null)
            {
                return RedirectToAction("Index", "SignIn");
            }

            return View(userInfo);
        }

        public async Task<IActionResult> Get(MasterDeviceStatusFilter param)
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

        public async Task<IActionResult> Detail(int id)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => _repoCollection.Detail(id));
            }
            catch (Exception ex)
            {
                resp.status = false;
                resp.exception = ex.Message;
            }

            return new JsonResult(resp);
        }

        public async Task<IActionResult> Create(MasterDeviceStatus param)
        {
            Response resp = new Response();

            try
            {
                UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

                if (userInfo == null)
                {
                    return RedirectToAction("Index", "SignIn");
                }
                else
                {
                    param.CreateBy = userInfo.UserName;
                    param.UpdateBy = userInfo.UserName;
                }

                resp = await Task.Run(() => _repoCollection.Create(param));
            }
            catch (Exception ex)
            {
                resp.status = false;
                resp.exception = ex.Message;
            }

            return new JsonResult(resp);
        }

        public async Task<IActionResult> Update(MasterDeviceStatus param)
        {
            Response resp = new Response();

            try
            {
                UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

                if (userInfo == null)
                {
                    return RedirectToAction("Index", "SignIn");
                }
                else
                {
                    param.CreateBy = userInfo.UserName;
                    param.UpdateBy = userInfo.UserName;
                }

                resp = await Task.Run(() => _repoCollection.Update(param));
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

