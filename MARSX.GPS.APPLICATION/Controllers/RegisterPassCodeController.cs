using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Customs;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.MasterAccountRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class RegisterPassCodeController : Controller
    {
        IConfiguration _configuration;

        private readonly IMasterAccountRepository _repoMasterAccountCollection;

        public RegisterPassCodeController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoMasterAccountCollection = new MasterAccountRepository(configuration);

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

            return View();
        }

        public async Task<IActionResult> UpdatePassCode(SysUser param)
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
                    param.Id = userInfo.Id;
                    param.CreateBy = userInfo.UserName;
                    param.UpdateBy = userInfo.UserName;
                }

                resp = await Task.Run(() => _repoMasterAccountCollection.UpdatePassCode(param));
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

