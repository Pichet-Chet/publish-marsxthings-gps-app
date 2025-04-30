using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.MasterDeviceGroupRepositories
{
	public interface IMasterDeviceGroupRepositories
	{
        Task<Response> Get(MasterDeviceGroupFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(MasterDeviceGroup param);

        Task<Response> Update(MasterDeviceGroup param);
    }
}

