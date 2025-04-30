using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
namespace MARSX.GPS.API.Repositories.SysDeviceFavoriteRepositories
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

