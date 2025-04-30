using System;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Reponse;

namespace MARSX.GPS.APPLICATION.Repositories.TcDevicesRepositories
{
	public interface ITcDevicesRepositories
	{
        Task<Response> Get(DevicesFilter param);
    }
}

