using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Repositories.MasterDeviceCategoryRepositories
{
	public class MasterDeviceCategoryRepositories : IMasterDeviceCategoryRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public MasterDeviceCategoryRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> Get(MasterDeviceCategoryFilter param)
        {
            Response resp = new Response();

            try
            {
                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceCategory/Get?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<List<MasterDeviceCategory>>(resp.data.ToString());
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

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceCategory/Detail?id=" + id);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceCategory>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public async Task<Response> Create(MasterDeviceCategory param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceCategory/Create/");

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceCategory>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }


        public async Task<Response> Update(MasterDeviceCategory param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/MasterDeviceCategory/Update/");

                HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<MasterDeviceCategory>(resp.data.ToString());
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

