using System;
using MARSX.GPS.APPLICATION.Models.Filters.TrackCar;
using MARSX.GPS.APPLICATION.Models.Reponse;
using System;
using MARSX.GPS.APPLICATION.Models;

namespace MARSX.GPS.APPLICATION.Repositories.SysLogsRepositories
{
	public interface ISysLogsRepositories
	{
        Task<Response> Create(SysLog param);
    }
}

