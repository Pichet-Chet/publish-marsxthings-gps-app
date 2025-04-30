using System;
using System.Net;
using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;
using System;
namespace MARSX.GPS.APPLICATION.Repositories.TcPositionRepositories
{
	public class TcPositionRepositories : ITcPositionRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public TcPositionRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> Get(PositionFilter param)
        {
            Response resp = new Response();

            try
            {
                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/TcPosition/Get?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<List<TcPosition>>(resp.data.ToString());
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

