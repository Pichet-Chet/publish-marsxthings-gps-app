using System;
using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MARSX.GPS.API.Models.Filters;

namespace MARSX.GPS.API.Repositories.SysLogsRepositories
{
	public interface ISysLogsRepositories
	{

        Task<Response> Create(SysLog param);
    }
}

