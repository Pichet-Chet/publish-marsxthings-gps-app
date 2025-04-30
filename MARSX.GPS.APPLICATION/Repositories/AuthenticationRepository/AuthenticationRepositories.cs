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

using System;

namespace MARSX.GPS.APPLICATION.Repositories.AuthenticationRepository
{
	public class AuthenticationRepositories : IAuthenticationRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public AuthenticationRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> SignIn(AuthenticationFilter param)
        {
            Response resp = new Response();

            try
            {
                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/Authentication/SignIn?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

                //if (resp.effectRow > 0)
                //{
                //    resp.data = JsonConvert.DeserializeObject<SysUser>(resp.data.ToString());
                //}

            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public async Task<Response> SignInWithPassCode(AuthenticationFilter param)
        {
            Response resp = new Response();

            try
            {
                var queryString = AppHelper.GetQueryString(param);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_domain + $"api/Authentication/SignInWithPassCode?" + queryString);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                string data = await Task.Run(() => response.Content.ReadAsStringAsync().Result);

                resp = JsonConvert.DeserializeObject<Response>(data);

            }
            catch (Exception ex)
            {
                resp.exception = ex.Message;
            }

            return resp;
        }

        public Task<Response> SignUp()
        {
            throw new NotImplementedException();
        }

        public Task<Response> SignOut()
        {
            throw new NotImplementedException();
        }

        public Task<Response> ChnagePassword()
        {
            throw new NotImplementedException();
        }

        public Task<Response> ResetPassword()
        {
            throw new NotImplementedException();
        }

        
    }
}

