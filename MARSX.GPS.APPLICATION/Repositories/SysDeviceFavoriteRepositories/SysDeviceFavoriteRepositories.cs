using MARSX.GPS.APPLICATION.Extension;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Repositories.SysDeviceFavoriteRepositories
{
	public class SysDeviceFavoriteRepositories : ISysDeviceFavoriteRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public SysDeviceFavoriteRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> Get(SysDeviceFavoriteFilter param)
        {
            Response resp = new Response();

            try
            {
                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/SysDeviceFavorite/Get?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<List<SysDeviceFavorite>>(resp.data.ToString());
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

                client.BaseAddress = new Uri(_domain + $"api/SysDeviceFavorite/Get?id=" + id);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<SysDeviceFavorite>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public async Task<Response> Create(SysDeviceFavorite param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/SysDeviceFavorite/Create");

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<SysDeviceFavorite>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }


        public async Task<Response> Update(SysDeviceFavorite param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/SysDeviceFavorite/Update");

                HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<SysDeviceFavorite>(resp.data.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public async Task<Response> Delete(SysDeviceFavorite param)
        {
            Response resp = new Response();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/SysDeviceFavorite/Delete");

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, param);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                if (resp.effectRow > 0)
                {
                    resp.data = JsonConvert.DeserializeObject<SysDeviceFavorite>(resp.data.ToString());
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

