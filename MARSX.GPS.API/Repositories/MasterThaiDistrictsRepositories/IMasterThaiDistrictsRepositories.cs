using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using System;
namespace MARSX.GPS.API.Repositories.MasterThaiDistrictsRepositories
{
	public interface IMasterThaiDistrictsRepositories
	{
        Task<Response> Get(MasterThaiDistrictFilter param);
    }
}

