using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterCountryRepositories
{
    public interface IMasterCountryRepositories
	{
        Task<Response> Get(MasterThaiDistrictsFilter param);
    }
}

