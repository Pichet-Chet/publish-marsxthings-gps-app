using System;
namespace MARSX.GPS.API.Models.Constants
{
	public class Constants
	{

        #region Genetal Message

        public const string userNameInvalid = "The user account was not found within the system.";

        public const string unitOfTime = "second.";

        public const string nullable = "N/A";

        public const string dataHasBeenSaved = "Data Saved Successfully.";

        public const string invalidDataDuplicate = "Duplicate information within the system";

        public const string invalidDataFormat = "The data format is incorrect.";

        public const string recordDataNotFound = "The searched information was not found.";

        public const string authenticationUsernameNotFound = "No user account found.";

        public const string authenticationInvalidPassword = "The password is incorrect.";

        public const string authenticationAccountBanned = "User account has been blocked.";

        public const string TcPositionDeviceIdRequired = "Please specify information Machine code.";

        public const int MachineDeviceUnknownDefaultId = 24;

        public const string tagActionDeviceAll = "ALL";
        public const string tagActionDeviceGpsOnline = "GPS-ONLINE";
        public const string tagActionDevicePowerOn = "POWER-ON";


        #endregion

        #region HTTP response status codes

        public const int httpCode200 = 200;
        public const string httpCode200Message = "OK";

        public const int httpCode300 = 300;
        public const string httpCode300Message = "Multiple Choices";

        public const int httpCode400 = 400;
        public const string httpCode400Message = "Bad Request";

        public const int httpCode401 = 401;
        public const string httpCode401Message = "Access denined";

        public const int httpCode429 = 429;
        public const string httpCode429Message = "Too many request";

        public const int httpCode500 = 500;
        public const string httpCode500Message = "Internal Server Error : The server has encountered a situation it does not know how to handle.";

        #endregion

        #region Type

        public const string msgSuccess = "Success";
        public const string msgError = "Error";
        public const string msgWarning = "Warning";

        #endregion

        #region Status

        public const bool statusSuccess = true;
        public const bool statusError = false;

        #endregion

        #region StatusCode

        public const int statusCodeOK = 100001;
        public const int statusCodeDataNotFound = 20001;
        public const int statusCodeDataDuplicate = 20002;
        public const int statusCodeParamRequired = 30011;
        public const int statusCodeParamInvalid = 30021;
        public const int statusCodeException = 90000;

        #endregion
    }
}

