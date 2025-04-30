using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
namespace MARSX.GPS.API.Repositories.SysGroupRepositories
{
	public interface ISysGroupRepositories
	{
        Task<Response> Get(SysGroupFilter param);
        Task<Response> Detail(int id);
        Task<Response> Create(SysGroup param);
        Task<Response> Update(SysGroup param);
    }
}

