using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterGpsStatusRepositories
{
	public interface IMasterGpsStatusRepositories
	{
        Task<Response> Get(MasterGpsStatusFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(MasterGpsStatus param);
        Task<Response> Update(MasterGpsStatus param);
    }
}

