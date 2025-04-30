using System;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Reponse;
using System;
namespace MARSX.GPS.APPLICATION.Repositories.TcPositionRepositories
{
	public interface ITcPositionRepositories
	{
        Task<Response> Get(PositionFilter param);
    }
}

