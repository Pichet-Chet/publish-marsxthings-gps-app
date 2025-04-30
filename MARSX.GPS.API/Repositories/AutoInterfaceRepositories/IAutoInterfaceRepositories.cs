using System;
using MARSX.GPS.API.Models.Reponse;

namespace MARSX.GPS.API.Repositories.AutoInterfaceRepositories
{
	public interface IAutoInterfaceRepositories
	{
        #region CarTrackService

        Task<Response> SyncDeviceFromCarTrackService();


        #endregion


        #region TC

        Task<Response> SyncDeviceFromTcService();

        #endregion



    }
}

