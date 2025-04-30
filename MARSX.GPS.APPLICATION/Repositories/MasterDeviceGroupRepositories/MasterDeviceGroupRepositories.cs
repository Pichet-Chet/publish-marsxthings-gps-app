using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Repositories.MasterDeviceGroupRepositories
{
	public class MasterDeviceGroupRepositories : IMasterDeviceGroupRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public MasterDeviceGroupRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> Get(MasterDeviceGroupFilter param)
        {
            Response resp = new Response();

            try
            {
                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceGroup/Get?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<List<MasterDeviceGroup>>(resp.data.ToString());
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

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceGroup/Detail?id=" + id);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceGroup>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public async Task<Response> Create(MasterDeviceGroup param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceGroup/Create/");

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceGroup>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }


        public async Task<Response> Update(MasterDeviceGroup param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceGroup/Update/");

                HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceGroup>(resp.data.ToString());
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

