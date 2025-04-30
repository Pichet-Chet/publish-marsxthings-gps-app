using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models.Customs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class MasterCompanyController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

            if (userInfo == null)
            {
                return RedirectToAction("Index", "SignIn");
            }


            return View(userInfo);
        }
    }
}

