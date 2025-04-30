using System;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Filters.TrackCar;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Models.Customs.MarsxTrack;

namespace MARSX.GPS.API.Repositories.TcDevices
{
	public interface ITcDevicesRepositories
    {
        Task<Response> Get(DevicesFilter param);
        Task<Response> DevicesByModel(string model);
        Task<Response> DevicesByGroup(int id);

    }
}

