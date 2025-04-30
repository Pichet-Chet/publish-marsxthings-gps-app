using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Customs;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.IdentityModel.Tokens;
using WatchDog;

namespace MARSX.GPS.API.Services
{
	public class AuthorizationService
	{
        IConfigurationRoot config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

        private readonly TrackerContext _context;

        public AuthorizationService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> GenerateToken(AuthorizationModel param)
        {
            Response resp = new Response();

            try
            {
                if (string.IsNullOrEmpty(param.UserName) || string.IsNullOrEmpty(param.Password))
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeException;
                    resp.message = Constants.userNameInvalid;
                }

                else
                {
                    string getCurrentUsername = config["Jwt:Username"];
                    string getCurrentPassword = config["Jwt:Password"];


                    if (param.UserName.Equals(getCurrentUsername) && param.Password.Equals(getCurrentPassword))
                    {
                        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);
                        var jwtSecurityToken = new JwtSecurityToken(
                            issuer: config["Jwt:Issuer"],
                            audience: config["Jwt:Audience"],
                            claims: new List<Claim>(),
                            expires: DateTime.Now.AddHours(10),
                            signingCredentials: signinCredentials
                        );


                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusSuccess;
                        resp.statusCode = Constants.statusCodeOK;
                        resp.data = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                        resp.message = "bearer " + new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    }

                    else
                    {
                        resp.httpCode = Constants.httpCode401;
                        resp.status = Constants.statusError;
                        resp.statusCode = Constants.statusCodeException;
                        resp.message = Constants.httpCode401Message;
                    }
                }

            }
            catch (Exception ex)
            {
                resp.httpCode = Constants.httpCode500;
                resp.status = Constants.statusError;
                resp.statusCode = Constants.statusCodeException;
                resp.message = Constants.httpCode500Message;
                resp.exception = ex.Message;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return resp;
        }
    }
}

