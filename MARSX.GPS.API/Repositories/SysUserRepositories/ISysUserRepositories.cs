using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MARSX.GPS.API.Repositories.SysUserRepositories
{
	public interface ISysUserRepositories
	{
        Task<Response> Get(SysUserFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(SysUser param);
        Task<Response> Update(SysUser param);
        Task<Response> UpdatePassCode(SysUser param);
    }
}

