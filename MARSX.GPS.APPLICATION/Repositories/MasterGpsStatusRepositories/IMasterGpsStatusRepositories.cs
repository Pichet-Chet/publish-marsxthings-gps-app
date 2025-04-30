using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.MasterGpsStatusRepositories
{
	public interface IMasterGpsStatusRepositories
	{
        Task<Response> Get(MasterGpsStatusFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(MasterGpsStatus param);

        Task<Response> Update(MasterGpsStatus param);
    }
}

