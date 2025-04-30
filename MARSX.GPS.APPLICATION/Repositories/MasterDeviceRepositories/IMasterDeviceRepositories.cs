using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.MasterDeviceRepositories
{
    public interface IMasterDeviceRepositories
	{
        Task<Response> Get(MasterDeviceFilter param);

        Task<Response> GetFirstRow(MasterDeviceFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(MasterDevice param);

        Task<Response> Update(MasterDevice param);
    }
}

