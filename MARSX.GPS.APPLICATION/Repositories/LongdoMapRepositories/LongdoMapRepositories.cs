using System;
using System.Net;
using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Longdo;
using MARSX.GPS.APPLICATION.Models.Customs.MarsxTrack;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Repositories.LongdoMapRepositories
{
	public class LongdoMapRepositories : ILongdoMapRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public LongdoMapRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<string> getKey()
        {
            string result = "";

            result = _configuration["LongdoMap:Key"];

            return result;
        }

        public async Task<Response> rerverseGeocoding(LongdoMapFilter param)
        {
            Response resp = new Response();

            try
            {
                param.key = _configuration["LongdoMap:Key"];

                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri($"https://api.longdo.com/map/services/address?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                var execute = JsonConvert.DeserializeObject<Geocoding>(data.ToString());

                if (execute != null)
                {
                    resp.httpCode = 200;
                    resp.status = true;
                    resp.data = execute;
                }
                else
                {
                    resp.httpCode = 400;
                    resp.status = true;
                    resp.data = null;
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }
    }
}

