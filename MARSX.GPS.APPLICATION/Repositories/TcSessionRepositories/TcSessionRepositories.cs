using System;
using System.Net;
using System.Net.WebSockets;
using MARSX.GPS.APPLICATION.Models.Customs.MarsxTrack;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Repositories.TcSessionRepositories
{
	public class TcSessionRepositories : ITcSessionRepositories
    {
        IConfiguration _configuration;
        private string _domain = string.Empty;

        public TcSessionRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _domain = _configuration["MarsxTrackApi"];
        }

        public async Task<Response> Create()
        {
            Response resp = new Response();

            WebSocketModel ws = new WebSocketModel();

            try
            {
                using (ClientWebSocket webSocket = new ClientWebSocket())
                {
                    var tcUrl = _configuration["TracCar:Url"];
                    var tcWs = _configuration["TracCar:WS"];
                    var tcPort = _configuration["TracCar:Port"];
                    var tcEmail = _configuration["TracCar:Email"];
                    var tcPassword = _configuration["TracCar:Password"];
                    var routeApi = "/api/session";

                    HttpClient client = new HttpClient();

                    var request = new HttpRequestMessage(HttpMethod.Post, tcUrl + tcPort + routeApi);

                    request.Headers.Add("Accept", "application/json");

                    var collection = new List<KeyValuePair<string, string>>();

                    collection.Add(new("email", tcEmail));

                    collection.Add(new("password", tcPassword));

                    var content = new FormUrlEncodedContent(collection);

                    request.Content = content;

                    var response = await client.SendAsync(request);

                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var textResponse = response.ToString();
                        var JSESSIONID = textResponse.Substring(textResponse.LastIndexOf("JSESSIONID="));
                        var GetCount = textResponse.Substring(textResponse.LastIndexOf("JSESSIONID=")).IndexOf(";", StringComparison.Ordinal);

                        var setCookie = JSESSIONID.Substring(0, GetCount);

                        ws.Ws = tcWs;
                        ws.Cookie = setCookie;

                        resp.httpCode = 200;
                        resp.status = true;
                        resp.data = ws;
                    }
                    else
                    {
                        resp.status = false;
                    }
                }
               
            }
            catch (Exception ex)
            {
                resp.status = false;
                resp.exception = ex.Message;
            }

            return resp;
        }

        

        public async Task<Response> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Close()
        {
            throw new NotImplementedException();
        }


    }
}

