using System;
using MARSX.GPS.API.Models.Filters.TrackCar;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.TcPositionRepositories
{
	public interface ITcPositionRepositories
	{
        Task<Response> Get(PositionFilter param);

        Task<Response> GetBySerial(string serial);

        Task<Response> GetBySerials(List<string> serials);

        Task<Response> ModelSerial(ModelSerialFilter param);

        Task<Response> ModelSerials(List<ModelSerialFilter> param);


    }
}

