using System;
using MARSX.GPS.API.Extension.Helper;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters.LongdoMap;
using MARSX.GPS.API.Models.LongdoMap;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WatchDog;

namespace MARSX.GPS.API.Services.Extension.Longdo
{
	public class LongdoService
	{
        IConfigurationRoot config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

        private readonly TrackerContext _context;

        private string _domain = string.Empty;

        public LongdoService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<string> rerverseGeocoding(LongdoMapFilter param)
        {
            string resp = string.Empty;

            try
            {
                param.key = config["LongdoMap:Key"];

                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri($"https://api.longdo.com/map/services/address?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                var execute = JsonConvert.DeserializeObject<Geocoding>(data.ToString());

                if (execute != null)
                {
                    resp = execute.road + " " + execute.subdistrict + " " + execute.district + " " + execute.province + " " + execute.postcode + " " + "(" + execute.country + ")";
                }
                else
                {
                    resp = string.Empty;
                }
            }
            catch (Exception ex)
            {
                resp = string.Empty;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return resp;
        }
    }
}

