using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterDeviceCategoryRepositories
{
	public interface IMasterDeviceCategoryRepositories
	{
        Task<Response> Get(MasterDeviceCategoryFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(MasterDeviceCategory param);
        Task<Response> Update(MasterDeviceCategory param);
    }
}

