using System;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Reponse;
using System;
using MARSX.GPS.APPLICATION.Models.Filters;

namespace MARSX.GPS.APPLICATION.Repositories.LongdoMapRepositories
{
	public interface ILongdoMapRepositories
	{

        Task<string> getKey();

        Task<Response> rerverseGeocoding(LongdoMapFilter param);

    }
}

