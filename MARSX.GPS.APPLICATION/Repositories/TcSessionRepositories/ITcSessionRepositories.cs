using System;
using MARSX.GPS.APPLICATION.Models.Reponse;

namespace MARSX.GPS.APPLICATION.Repositories.TcSessionRepositories
{
	public interface ITcSessionRepositories
	{
        Task<Response> Get();

        Task<Response> Create();

        Task<Response> Close();

    }
}

