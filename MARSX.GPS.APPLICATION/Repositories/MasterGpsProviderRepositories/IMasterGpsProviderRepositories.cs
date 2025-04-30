using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Models;
namespace MARSX.GPS.APPLICATION.Repositories.MasterGpsProviderRepositories
{
	public interface IMasterGpsProviderRepositories
	{
        Task<Response> Get(MasterGpsProviderFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(MasterGpsProvider param);

        Task<Response> Update(MasterGpsProvider param);
    }
}

