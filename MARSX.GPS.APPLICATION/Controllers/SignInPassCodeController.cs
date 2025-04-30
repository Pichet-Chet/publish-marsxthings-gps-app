using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Customs;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.AuthenticationRepository;
using MARSX.GPS.APPLICATION.Repositories.LongdoMapRepositories;
using MARSX.GPS.APPLICATION.Repositories.SysLogsRepositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class SignInPassCodeController : Controller
    {
        IConfiguration _configuration;

        private readonly IAuthenticationRepositories _repoCollection;

        private readonly ISysLogsRepositories _repoSysLog;

        private readonly ILongdoMapRepositories _repoLongdoMap;

        public SignInPassCodeController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new AuthenticationRepositories(configuration);

            _repoSysLog = new SysLogsRepositories(configuration);

            _repoLongdoMap = new LongdoMapRepositories(configuration);

        }
        // GET: /<controller>/
        public IActionResult Index([FromQuery] AuthenticationFilter param)
        {
            if (string.IsNullOrEmpty(param.UserName))
            {
                return RedirectToAction("Index", "SignIn");
            }

            return View();
        }

        public async Task<IActionResult> VerifyAccount(AuthenticationFilter param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => _repoCollection.SignInWithPassCode(param));

                if (resp.status == true)
                {
                    var GetIpAddress = this.HttpContext.Connection.RemoteIpAddress?.ToString();

                    var GetIpAddressMac = Request.HttpContext.Connection.LocalIpAddress;

                    string GetMachineName = Environment.MachineName;

                    SysLog sysLog = new SysLog();

                    sysLog.UserName = param.UserName;
                    sysLog.ClientLatitude = param.ClientLatitude;
                    sysLog.ClientLongitude = param.ClientLongitude;
                    sysLog.ClientAgent = param.ClientAgent;
                    sysLog.ClientBrowser = param.ClientBrowser;
                    sysLog.ClientPlatform = param.ClientPlatform;
                    sysLog.ClientLanguage = param.ClientLanguage;
                    sysLog.ClientDevice = param.ClientDevice;
                    sysLog.ClientDatetime = param.ClientDatetime;
                    sysLog.ClientIp = param.ClientIp;
                    sysLog.ServerDatetime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                    await Task.Run(() => _repoSysLog.Create(sysLog));

                    UserInfo userInfo = new UserInfo();

                    SysUser sysUser = new SysUser();

                    sysUser = JsonConvert.DeserializeObject<SysUser>(resp.data.ToString());

                    userInfo.Id = sysUser.Id;
                    userInfo.UserName = sysUser.UserName;
                    userInfo.Email = sysUser.Email;
                    userInfo.longdoMapKey = await Task.Run(() => _repoLongdoMap.getKey());


                    SessionHelper.SetObjectAsJson(this.HttpContext.Session, "UserInfo", userInfo);
                }
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

