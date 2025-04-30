using System;
using System.Linq;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Customs;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace MARSX.GPS.API.Services
{
    public class AuthenticationService
    {
        private readonly TrackerContext _context;

        public AuthenticationService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> AuthenticationSignIn(AuthorizationModel param)
        {
            Response resp = new Response();

            SysUser objData = new SysUser();

            try
            {
                var findUsername = await Task.Run(() => _context.SysUsers.Where(x => x.UserName.ToLower() == param.UserName.ToLower()).ToList());

                if (findUsername != null && findUsername.Count > 0)
                {
                    findUsername = findUsername.Where(x => x.Password == param.Password).ToList();

                    if (findUsername != null && findUsername.Count > 0)
                    {

                        var execute = findUsername.FirstOrDefault();

                        if (execute.IsActive == true)
                        {
                            objData = execute;

                            resp.httpCode = Constants.httpCode200;
                            resp.status = Constants.statusSuccess;
                            resp.statusCode = Constants.statusCodeOK;
                            resp.effectRow = 1;

                            resp.data = objData;
                        }
                        else
                        {
                            resp.httpCode = Constants.httpCode200;
                            resp.status = Constants.statusError;
                            resp.statusCode = Constants.statusCodeDataNotFound;
                            resp.message = Constants.authenticationAccountBanned;
                            resp.data = execute;
                        }
                    }
                    else
                    {
                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusError;
                        resp.statusCode = Constants.statusCodeDataNotFound;
                        resp.message = Constants.authenticationInvalidPassword;

                        resp.data = await Task.Run(() => _context.SysUsers.Where(x => x.UserName.ToLower() == param.UserName.ToLower()).FirstOrDefault());
                    }
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.authenticationUsernameNotFound;
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

        public async Task<Response> AuthenticationSignInWithPassCode(AuthorizationModel param)
        {
            Response resp = new Response();

            SysUser objData = new SysUser();

            try
            {
                var findUsername = await Task.Run(() => _context.SysUsers.Where(x => x.UserName.ToLower() == param.UserName.ToLower()).ToList());

                if (findUsername != null && findUsername.Count > 0)
                {
                    findUsername = findUsername.Where(x => x.PassCode == param.Passcode).ToList();

                    if (findUsername != null && findUsername.Count > 0)
                    {
                        var execute = findUsername.FirstOrDefault();

                        if (execute.IsActive == true)
                        {
                            objData = execute;

                            resp.httpCode = Constants.httpCode200;
                            resp.status = Constants.statusSuccess;
                            resp.statusCode = Constants.statusCodeOK;
                            resp.effectRow = 1;

                            resp.data = objData;
                        }
                        else
                        {
                            resp.httpCode = Constants.httpCode200;
                            resp.status = Constants.statusError;
                            resp.statusCode = Constants.statusCodeDataNotFound;
                            resp.message = Constants.authenticationAccountBanned;
                            resp.data = execute;
                        }
                    }
                    else
                    {
                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusError;
                        resp.statusCode = Constants.statusCodeDataNotFound;
                        resp.message = Constants.authenticationInvalidPassword;

                        resp.data = await Task.Run(() => _context.SysUsers.Where(x => x.UserName.ToLower() == param.UserName.ToLower()).FirstOrDefault());
                    }
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.authenticationUsernameNotFound;
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

        public async Task<Response> AuthenticationUserInformation(AuthorizationModel param)
        {
            Response resp = new Response();

            SysUser objData = new SysUser();

            try
            {
                var execute = await Task.Run(() => _context.SysUsers.Where(x => x.UserName.ToLower() == param.UserName.ToLower()).FirstOrDefault());

                if (objData != null)
                {
                    objData.UserName = execute.UserName;
                    objData.FirstNameTh = execute.FirstNameTh;
                    objData.LastNameTh = execute.LastNameTh;
                    objData.FirstNameEn = execute.FirstNameEn;
                    objData.LastNameEn = execute.LastNameEn;
                    objData.Age = execute.Age;
                    objData.Gender = execute.Gender;
                    objData.Email = execute.Email;
                    objData.IsActive = execute.IsActive;


                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.data = objData;
                }
                else
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusError;
                    resp.statusCode = Constants.statusCodeDataNotFound;
                    resp.message = Constants.recordDataNotFound;
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

