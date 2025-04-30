using System;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterThaiSubdistrictsRepositories
{
	public interface IMasterThaiSubdistrictsRepositories
	{
        Task<Response> Get(MasterThaiSubdistrictFilter param);
    }
}

