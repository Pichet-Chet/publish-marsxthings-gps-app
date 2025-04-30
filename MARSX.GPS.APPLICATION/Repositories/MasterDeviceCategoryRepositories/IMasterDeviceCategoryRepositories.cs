using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.MasterDeviceCategoryRepositories
{
	public interface IMasterDeviceCategoryRepositories
	{
        Task<Response> Get(MasterDeviceCategoryFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(MasterDeviceCategory param);

        Task<Response> Update(MasterDeviceCategory param);
    }
}

