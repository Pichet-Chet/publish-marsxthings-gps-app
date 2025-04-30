using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Customs;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.SysDeviceFavoriteRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class SysDeviceFavoriteController : Controller
    {
        IConfiguration _configuration;

        private readonly ISysDeviceFavoriteRepositories _repoCollection;

        public SysDeviceFavoriteController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new SysDeviceFavoriteRepositories(configuration);

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(SysDeviceFavorite param)
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
                    param.UserName = userInfo.UserName;
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


        public async Task<IActionResult> Delete(SysDeviceFavorite param)
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
                    param.UserName = userInfo.UserName;
                }

                resp = await Task.Run(() => _repoCollection.Delete(param));
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

