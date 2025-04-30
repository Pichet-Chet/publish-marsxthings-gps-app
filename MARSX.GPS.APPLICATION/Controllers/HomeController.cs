using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Customs;
using MARSX.GPS.APPLICATION.Extension;

namespace MARSX.GPS.APPLICATION.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        return Redirect("http://ec2-18-143-114-161.ap-southeast-1.compute.amazonaws.com:8082");

        UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

        if (userInfo == null)
        {
            return RedirectToAction("Index", "SignIn");
        }


        return View(userInfo);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}

