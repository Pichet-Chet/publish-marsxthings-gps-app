using System;
using MARSX.GPS.API.Models.Customs;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.AuthenticationRepositories
{
	public interface IAuthenticationRepositories
	{
        Task<Response> AuthenticationSignIn(AuthorizationModel param);

        Task<Response> AuthenticationSignInWithPassCode(AuthorizationModel param);

        Task<Response> AuthenticationUserInformation(AuthorizationModel param);

    }
}

