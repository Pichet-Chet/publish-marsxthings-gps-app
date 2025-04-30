using System;
using System.Net;
using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Customs.MarsxTrack;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;


namespace MARSX.GPS.APPLICATION.Repositories.SysLogsRepositories
{
	public class SysLogsRepositories : ISysLogsRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public SysLogsRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> Create(SysLog param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/SysLogs/Create?");

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<List<TcDevicesView>>(resp.data.ToString());
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

