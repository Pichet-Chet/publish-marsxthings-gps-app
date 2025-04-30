using System;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using System;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.SysDeviceFavoriteRepositories
{
	public interface ISysDeviceFavoriteRepositories
	{
        Task<Response> Get(SysDeviceFavoriteFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(SysDeviceFavorite param);

        Task<Response> Update(SysDeviceFavorite param);

        Task<Response> Delete(SysDeviceFavorite param);
    }
}

