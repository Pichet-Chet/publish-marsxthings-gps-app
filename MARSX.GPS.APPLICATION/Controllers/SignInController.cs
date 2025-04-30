using System.Net.NetworkInformation;
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
using System.Management;
using System.Net.NetworkInformation;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class SignInController : Controller
    {
        IConfiguration _configuration;

        private readonly IAuthenticationRepositories _repoCollection;

        private readonly ISysLogsRepositories _repoSysLog;

        private readonly ILongdoMapRepositories _repoLongdoMap;

        public SignInController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new AuthenticationRepositories(configuration);

            _repoSysLog = new SysLogsRepositories(configuration);

            _repoLongdoMap = new LongdoMapRepositories(configuration);

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

            if (userInfo != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> VerifyAccount(AuthenticationFilter param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => _repoCollection.SignIn(param));

                if (resp.status == true)
                {
                    //var GetIpAddress = this.HttpContext.Connection.RemoteIpAddress?.ToString();

                    //var GetIpAddressMac = Request.HttpContext.Connection.LocalIpAddress;

                    //string GetMachineName = Environment.MachineName;

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
                    sysLog.IspName = param.IspName;
                    sysLog.IspCountry = param.IspCountry;
                    

                    await Task.Run(() => _repoSysLog.Create(sysLog));

                    UserInfo userInfo = new UserInfo();

                    SysUser sysUser = new SysUser();

                    sysUser = JsonConvert.DeserializeObject<SysUser>(resp.data.ToString());

                    userInfo.Id = sysUser.Id;
                    userInfo.UserName = sysUser.UserName;
                    userInfo.Email = sysUser.Email;
                    userInfo.longdoMapKey = await Task.Run(() => _repoLongdoMap.getKey());

                    SessionHelper.SetObjectAsJson(this.HttpContext.Session, "UserInfo", userInfo);

                    resp.data = sysUser;
                }
            }
            catch (Exception ex)
            {
                resp.status = false;
                resp.exception = ex.Message;
            }

            return new JsonResult(resp);
        }

        static NetworkInterface GetConnectedWifiNetwork()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();

            var connectedWifiInterface = interfaces.OrderByDescending(x => x.Speed).FirstOrDefault(
                ni => ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                      ni.OperationalStatus == OperationalStatus.Up);

            return connectedWifiInterface;
        }



    }
}

