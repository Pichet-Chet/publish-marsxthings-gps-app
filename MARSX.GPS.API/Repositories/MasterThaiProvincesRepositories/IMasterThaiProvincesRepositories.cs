using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using System;
namespace MARSX.GPS.API.Repositories.MasterThaiProvincesRepositories
{
	public interface IMasterThaiProvincesRepositories
	{
        Task<Response> Get(MasterThaiProvincesFilter param);
    }
}

