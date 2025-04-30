using System;
using MARSX.GPS.APPLICATION.Models;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;

namespace MARSX.GPS.APPLICATION.Repositories.MasterAccountRepository
{
	public interface IMasterAccountRepository
	{
        Task<Response> Get(SysUserFilter param);

        Task<Response> UpdatePassCode(SysUser param);
    }
}

