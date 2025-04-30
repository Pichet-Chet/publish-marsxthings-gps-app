using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterGpsProviderRepositories
{
	public interface IMasterGpsProviderRepositories
	{
        Task<Response> Get(MasterGpsProviderFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(MasterGpsProvider param);
        Task<Response> Update(MasterGpsProvider param);
    }
}

