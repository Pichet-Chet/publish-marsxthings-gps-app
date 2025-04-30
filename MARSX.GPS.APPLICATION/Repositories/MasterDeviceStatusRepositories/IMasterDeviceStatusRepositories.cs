using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.MasterDeviceStatusRepositories
{
	public interface IMasterDeviceStatusRepositories
	{
        Task<Response> Get(MasterDeviceStatusFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(MasterDeviceStatus param);

        Task<Response> Update(MasterDeviceStatus param);
    }
}

