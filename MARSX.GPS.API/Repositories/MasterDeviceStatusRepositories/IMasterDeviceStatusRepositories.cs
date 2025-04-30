using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterDeviceStatusRepositories
{
    public interface IMasterDeviceStatusRepositories
	{
        Task<Response> Get(MasterDeviceStatusFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(MasterDeviceStatus param);
        Task<Response> Update(MasterDeviceStatus param);
    }
}

