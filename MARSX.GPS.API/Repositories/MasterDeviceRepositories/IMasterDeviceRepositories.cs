using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.MasterDeviceRepositories
{
    public interface IMasterDeviceRepositories
	{
        Task<Response> Get(MasterDeviceFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(MasterDevice param);
        Task<Response> Update(MasterDevice param);
    }
}

