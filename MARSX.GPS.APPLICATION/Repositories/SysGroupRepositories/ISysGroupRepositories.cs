using System;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;
using System;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.SysGroupRepositories
{
	public interface ISysGroupRepositories
	{
        Task<Response> Get(SysGroupFilter param);

        Task<Response> Detail(int id);

        Task<Response> Create(SysGroup param);

        Task<Response> Update(SysGroup param);
    }
}

