using System;
using MARSX.GPS.API.Models.Customs;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.AuthorizationRepositories
{
	public interface IAuthorizationRepositories
	{
        Task<Response> GenerateToken(AuthorizationModel param);
    }
}

