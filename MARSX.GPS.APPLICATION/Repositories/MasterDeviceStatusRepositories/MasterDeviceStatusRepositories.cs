using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Repositories.MasterDeviceStatusRepositories
{
	public class MasterDeviceStatusRepositories : IMasterDeviceStatusRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public MasterDeviceStatusRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> Get(MasterDeviceStatusFilter param)
        {
            Response resp = new Response();

            try
            {
                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceStatus/Get?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<List<MasterDeviceStatus>>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public async Task<Response> Detail(int id)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceStatus/Detail?id=" + id);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceStatus>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public async Task<Response> Create(MasterDeviceStatus param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceStatus/Create/");

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceStatus>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }


        public async Task<Response> Update(MasterDeviceStatus param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceStatus/Update/");

                HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceStatus>(resp.data.ToString());
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

