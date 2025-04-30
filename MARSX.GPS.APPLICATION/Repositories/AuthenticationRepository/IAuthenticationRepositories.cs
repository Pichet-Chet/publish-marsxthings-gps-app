using System;
using MARSX.GPS.APPLICATION.Models.Filters;
using MARSX.GPS.APPLICATION.Models.Reponse;

namespace MARSX.GPS.APPLICATION.Repositories.AuthenticationRepository
{
	public interface IAuthenticationRepositories
	{
        Task<Response> SignIn(AuthenticationFilter param);

        Task<Response> SignInWithPassCode(AuthenticationFilter param);


        Task<Response> SignUp();

        Task<Response> SignOut();

        Task<Response> ChnagePassword();

        Task<Response> ResetPassword();
    }
}

