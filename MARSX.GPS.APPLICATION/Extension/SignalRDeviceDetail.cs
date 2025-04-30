using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using MARSX.GPS.APPLICATION.Models.Reponse;
using Microsoft.Extensions.Configuration;
using MARSX.GPS.APPLICATION.Repositories.MasterDeviceRepositories;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Customs.MarsxTrack;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Extension
{
	public class SignalRDeviceDetail : Hub
    {
        IConfiguration _configuration;

        private readonly IMasterDeviceRepositories _repoCollection;

        public SignalRDeviceDetail(IConfiguration configuration)
        {
            _configuration = configuration;

            _repoCollection = new MasterDeviceRepositories(configuration);

        }

        private static Response resp = new Response();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task<Response> GetDeviceDeatil(int deviceId)
        {
            MasterDeviceFilter param = new MasterDeviceFilter();

            param.Id = deviceId;

            resp = await _repoCollection.GetFirstRow(param);

            deviceId = 0;

            return resp;
        }
    }
}

