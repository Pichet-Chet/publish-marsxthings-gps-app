using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models.Customs;
using MARSX.GPS.APPLICATION.Models.Customs.MarsxTrack;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Repositories.MasterDeviceRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARSX.GPS.APPLICATION.Controllers
{
    public class DeviceInfoController : Controller
    {
        IConfiguration _configuration;

        private readonly IMasterDeviceRepositories _repoMasterDeviceCollection;

        public DeviceInfoController(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoMasterDeviceCollection = new MasterDeviceRepositories(configuration);

        }
        // GET: /<controller>/
        //public async Task<IActionResult> Index(int deviceId)
        //{
        //    UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

        //    if (userInfo == null)
        //    {
        //        return RedirectToAction("Index", "SignIn");
        //    }

        //    Response resp = new Response();

        //    MasterDeviceFilter param = new MasterDeviceFilter();

        //    MasterDeviceView result = new MasterDeviceView();

        //    param.Id = deviceId;

        //    try
        //    {
        //        resp = await Task.Run(() => _repoMasterDeviceCollection.Get(param));

        //        var getJsonReturn = JsonConvert.SerializeObject(resp.data);

        //        List<MasterDeviceView> convertJson = JsonConvert.DeserializeObject<List<MasterDeviceView>>(getJsonReturn);

        //        result = convertJson == null ? null : convertJson.FirstOrDefault();

        //        result.LongdoMap.key = userInfo.longdoMapKey;
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.status = false;
        //        resp.exception = ex.Message;

        //    }

        //    return PartialView("Index", result);

        //    //return View(result);
        //}

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] MasterDeviceView param)
        {
            UserInfo userInfo = SessionHelper.GetObjectFromJson<UserInfo>(this.HttpContext.Session, "UserInfo");

            if (userInfo == null)
            {
                return RedirectToAction("Index", "SignIn");
            }

            Response resp = new Response();

            try
            {
                //result = JsonConvert.DeserializeObject<MasterDeviceView>(param);

                param.LongdoMap.key = userInfo.longdoMapKey;

            }
            catch (Exception ex)
            {
                resp.status = false;
                resp.exception = ex.Message;

            }

            return PartialView("Index", param);

            //return View(result);
        }
    }
}

