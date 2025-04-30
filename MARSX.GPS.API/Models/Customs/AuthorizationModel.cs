using System;
namespace MARSX.GPS.API.Models.Customs
{
	public class AuthorizationModel
	{
        public AuthorizationModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Passcode { get; set; }
    }
}

