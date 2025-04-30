using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterDeviceGroupRepositories
{
	public interface IMasterDeviceGroupRepositories
	{
        Task<Response> Get(MasterDeviceGroupFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(MasterDeviceGroup param);
        Task<Response> Update(MasterDeviceGroup param);
    }
}

