using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.SysLogsApiRepositories
{
	public interface ISysLogApiRepositories
	{
        Task<Response> Create(SysLogApi param);
    }
}

