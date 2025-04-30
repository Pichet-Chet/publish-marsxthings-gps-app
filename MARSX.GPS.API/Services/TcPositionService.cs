using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Filters.TrackCar;
using MARSX.GPS.API.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using System;
using WatchDog;
using MARSX.GPS.API.Models.Customs.MarsxTrack;
using Newtonsoft.Json;

namespace MARSX.GPS.API.Services
{
    public class TcPositionService
    {
        private readonly TrackerContext _context;

        public TcPositionService(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Response> Get(PositionFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            try
            {

                var queryable = await Task.Run(() => _context.TcPositions.AsQueryable());

                #region Filter Data

                if (param.from != null && param.to != null)
                {
                    queryable = queryable.Where(x => x.Deviceid == param.deviceId).AsQueryable();

                    queryable = queryable.Where(x => x.Servertime >= param.from).AsQueryable();

                    queryable = queryable.Where(x => x.Servertime <= param.to).AsQueryable();
                }
                else
                {
                    if (param.id != null)
                    {
                        queryable = queryable.Where(x => x.Id == param.id).AsQueryable();
                    }

                    if (param.deviceId != null)
                    {
                        queryable = queryable.Where(x => x.Deviceid == param.deviceId).AsQueryable();
                    }
                }



                List<TcPosition> execute = new List<TcPosition>();

                execute = queryable.AsNoTracking().ToList();

                #endregion


                if (param.isAll != null)
                {
                    if (param.isAll == true)
                    {
                        execute = execute.ToList();
                    }
                    else
                    {
                        execute = execute
                       .Skip((param.PageNumber - 1) * param.PageSize)
                       .Take(param.PageSize)
                       .ToList();
                    }
                }
                else
                {
                    execute = execute
                   .Skip((param.PageNumber - 1) * param.PageSize)
                   .Take(param.PageSize)
                   .ToList();
                }

                if (execute != null && execute.Count > 0)
                {
                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.data = execute;

                    resp.pageNumber = param.PageNumber;
                    resp.pageSize = param.PageSize;
                    resp.effectRow = execute.Count();
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

        public async Task<Response> ModelSerial(ModelSerialFilter param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            TcPositionView tcPositionView = new TcPositionView();

            try
            {
                var queryable = await Task.Run(() => _context.TcPositions.AsQueryable());

                var queryMasterDevice = await Task.Run(() => _context.MasterDevices.Where(x => x.Model != null).AsQueryable());

                queryMasterDevice = queryMasterDevice.Where(x => x.Model.ToLower() == param.Model.ToLower() && x.SerialNo == param.Serial).AsQueryable();

                var executeMasterDevice = queryMasterDevice.FirstOrDefault();

                if (executeMasterDevice != null && !string.IsNullOrEmpty(executeMasterDevice.RefTrackingId))
                {
                    var findTcDevice = await Task.Run(() => _context.TcDevices.Where(x => x.Uniqueid == executeMasterDevice.RefTrackingId).FirstOrDefault());

                    if (findTcDevice != null)
                    {
                        TcPosition tcPosition = new TcPosition();
                        TcAttributesView tcAttribute = new TcAttributesView();

                        var getLastPosition = await Task.Run(() => _context.TcPositions.Where(x => x.Deviceid == findTcDevice.Id).OrderByDescending(x => x.Id).FirstOrDefault());

                        tcPosition.Id = getLastPosition.Id;
                        tcPosition.Protocol = getLastPosition.Protocol;
                        //tcPosition.Deviceid = getLastPosition.Deviceid;
                        tcPosition.Servertime = getLastPosition.Servertime;
                        tcPosition.Devicetime = getLastPosition.Devicetime;
                        tcPosition.Fixtime = getLastPosition.Fixtime;
                        tcPosition.Valid = getLastPosition.Valid;
                        tcPosition.Latitude = getLastPosition.Latitude;
                        tcPosition.Longitude = getLastPosition.Longitude;
                        tcPosition.Altitude = getLastPosition.Altitude;
                        tcPosition.Speed = getLastPosition.Speed;
                        tcPosition.Course = getLastPosition.Course;
                        tcPosition.Address = getLastPosition.Address;
                        tcPosition.Accuracy = getLastPosition.Accuracy;
                        tcPosition.Network = getLastPosition.Network;
                        tcPosition.Geofenceids = getLastPosition.Geofenceids;
                        //tcPosition.Device = getLastPosition.Device;

                        tcAttribute = JsonConvert.DeserializeObject<TcAttributesView>(getLastPosition.Attributes);
                        tcAttribute.odometer = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                        tcAttribute.totalDistance = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                        tcAttribute.hours = tcAttribute.hours == null ? null : tcAttribute.hours / 1000 / 60 / 60;

                        tcPositionView.tcPosition = tcPosition;
                        tcPositionView.tcAttribute = tcAttribute;


                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusSuccess;
                        resp.statusCode = Constants.statusCodeOK;
                        resp.data = tcPositionView;
                    }
                    else
                    {
                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusError;
                        resp.statusCode = Constants.statusCodeDataNotFound;
                        resp.message = Constants.recordDataNotFound;
                    }
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

        public async Task<Response> ModelSerials(List<ModelSerialFilter> param) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            TcPositionView tcPositionView = new TcPositionView();

            try
            {
                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        var queryable = await Task.Run(() => _context.TcPositions.AsQueryable());

                        var queryMasterDevice = await Task.Run(() => _context.MasterDevices.Where(x => x.Model != null).AsQueryable());

                        queryMasterDevice = queryMasterDevice.Where(x => x.Model.ToLower() == item.Model.ToLower() && x.SerialNo == item.Serial).AsQueryable();

                        var executeMasterDevice = queryMasterDevice.FirstOrDefault();

                        if (executeMasterDevice != null && !string.IsNullOrEmpty(executeMasterDevice.RefTrackingId))
                        {
                            var findTcDevice = await Task.Run(() => _context.TcDevices.Where(x => x.Uniqueid == executeMasterDevice.RefTrackingId).FirstOrDefault());

                            if (findTcDevice != null)
                            {
                                TcPosition tcPosition = new TcPosition();
                                TcAttributesView tcAttribute = new TcAttributesView();

                                var getLastPosition = await Task.Run(() => _context.TcPositions.Where(x => x.Deviceid == findTcDevice.Id).OrderByDescending(x => x.Id).FirstOrDefault());

                                tcPosition.Id = getLastPosition.Id;
                                tcPosition.Protocol = getLastPosition.Protocol;
                                //tcPosition.Deviceid = getLastPosition.Deviceid;
                                tcPosition.Servertime = getLastPosition.Servertime;
                                tcPosition.Devicetime = getLastPosition.Devicetime;
                                tcPosition.Fixtime = getLastPosition.Fixtime;
                                tcPosition.Valid = getLastPosition.Valid;
                                tcPosition.Latitude = getLastPosition.Latitude;
                                tcPosition.Longitude = getLastPosition.Longitude;
                                tcPosition.Altitude = getLastPosition.Altitude;
                                tcPosition.Speed = getLastPosition.Speed;
                                tcPosition.Course = getLastPosition.Course;
                                tcPosition.Address = getLastPosition.Address;
                                tcPosition.Accuracy = getLastPosition.Accuracy;
                                tcPosition.Network = getLastPosition.Network;
                                tcPosition.Geofenceids = getLastPosition.Geofenceids;
                                //tcPosition.Device = getLastPosition.Device;

                                tcAttribute = JsonConvert.DeserializeObject<TcAttributesView>(getLastPosition.Attributes);
                                tcAttribute.odometer = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                                tcAttribute.totalDistance = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                                tcAttribute.hours = tcAttribute.hours == null ? null : tcAttribute.hours / 1000 / 60 / 60;

                                tcPositionView.tcPosition = tcPosition;
                                tcPositionView.tcAttribute = tcAttribute;


                                resp.httpCode = Constants.httpCode200;
                                resp.status = Constants.statusSuccess;
                                resp.statusCode = Constants.statusCodeOK;
                                resp.data = tcPositionView;
                            }
                            else
                            {
                                resp.httpCode = Constants.httpCode200;
                                resp.status = Constants.statusError;
                                resp.statusCode = Constants.statusCodeDataNotFound;
                                resp.message = Constants.recordDataNotFound;
                            }
                        }
                        else
                        {
                            resp.httpCode = Constants.httpCode200;
                            resp.status = Constants.statusError;
                            resp.statusCode = Constants.statusCodeDataNotFound;
                            resp.message = Constants.recordDataNotFound;
                        }
                    }
                }
                else
                {

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


        public async Task<Response> GetBySerial(string serial) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            TcPositionView tcPositionView = new TcPositionView();

            try
            {
                var queryable = await Task.Run(() => _context.TcPositions.AsQueryable());

                var queryMasterDevice = await Task.Run(() => _context.MasterDevices.Where(x => x.SerialNo != null && x.Chassis != null).AsQueryable());

                queryMasterDevice = queryMasterDevice.Where(x => x.SerialNo == serial || x.Chassis == serial).AsQueryable();

                var executeMasterDevice = queryMasterDevice.FirstOrDefault();

                if (executeMasterDevice != null && !string.IsNullOrEmpty(executeMasterDevice.RefTrackingId))
                {
                    var findTcDevice = await Task.Run(() => _context.TcDevices.Where(x => x.Uniqueid == executeMasterDevice.RefTrackingId).FirstOrDefault());

                    if (findTcDevice != null)
                    {
                        TcPosition tcPosition = new TcPosition();
                        TcAttributesView tcAttribute = new TcAttributesView();

                        var getLastPosition = await Task.Run(() => _context.TcPositions.Where(x => x.Deviceid == findTcDevice.Id).OrderByDescending(x => x.Id).FirstOrDefault());

                        tcPosition.Id = getLastPosition.Id;
                        tcPosition.Protocol = getLastPosition.Protocol;
                        //tcPosition.Deviceid = getLastPosition.Deviceid;
                        tcPosition.Servertime = getLastPosition.Servertime;
                        tcPosition.Devicetime = getLastPosition.Devicetime;
                        tcPosition.Fixtime = getLastPosition.Fixtime;
                        tcPosition.Valid = getLastPosition.Valid;
                        tcPosition.Latitude = getLastPosition.Latitude;
                        tcPosition.Longitude = getLastPosition.Longitude;
                        tcPosition.Altitude = getLastPosition.Altitude;
                        tcPosition.Speed = getLastPosition.Speed;
                        tcPosition.Course = getLastPosition.Course;
                        tcPosition.Address = getLastPosition.Address;
                        tcPosition.Accuracy = getLastPosition.Accuracy;
                        tcPosition.Network = getLastPosition.Network;
                        tcPosition.Geofenceids = getLastPosition.Geofenceids;
                        //tcPosition.Device = getLastPosition.Device;

                        tcAttribute = JsonConvert.DeserializeObject<TcAttributesView>(getLastPosition.Attributes);
                        tcAttribute.odometer = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                        tcAttribute.totalDistance = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                        tcAttribute.hours = tcAttribute.hours == null ? null : tcAttribute.hours / 1000 / 60 / 60;

                        tcPositionView.tcPosition = tcPosition;
                        tcPositionView.tcAttribute = tcAttribute;


                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusSuccess;
                        resp.statusCode = Constants.statusCodeOK;
                        resp.data = tcPositionView;
                    }
                    else
                    {
                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusError;
                        resp.statusCode = Constants.statusCodeDataNotFound;
                        resp.message = Constants.recordDataNotFound;
                    }
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


        public async Task<Response> GetBySerials(List<string> serials) // Additional models are imported from GlobalFilter and PaginationModel
        {
            Response resp = new Response();

            List<TcPositionView> result = new List<TcPositionView>();

            try
            {
                if (serials != null && serials.Count > 0)
                {
                    foreach (var serial in serials)
                    {
                        TcPositionView tcPositionView = new TcPositionView();

                        var queryable = await Task.Run(() => _context.TcPositions.AsQueryable());

                        var queryMasterDevice = await Task.Run(() => _context.MasterDevices.Where(x => x.SerialNo != null && x.Chassis != null).AsQueryable());

                        queryMasterDevice = queryMasterDevice.Where(x => x.SerialNo == serial || x.Chassis == serial).AsQueryable();

                        var executeMasterDevice = queryMasterDevice.FirstOrDefault();

                        if (executeMasterDevice != null && !string.IsNullOrEmpty(executeMasterDevice.RefTrackingId))
                        {
                            var findTcDevice = await Task.Run(() => _context.TcDevices.Where(x => x.Uniqueid == executeMasterDevice.RefTrackingId).FirstOrDefault());

                            if (findTcDevice != null)
                            {
                                TcPosition tcPosition = new TcPosition();
                                TcAttributesView tcAttribute = new TcAttributesView();

                                var getLastPosition = await Task.Run(() => _context.TcPositions.Where(x => x.Deviceid == findTcDevice.Id).OrderByDescending(x => x.Id).FirstOrDefault());

                                tcPosition.Id = getLastPosition.Id;
                                tcPosition.Protocol = getLastPosition.Protocol;
                                //tcPosition.Deviceid = getLastPosition.Deviceid;
                                tcPosition.Servertime = getLastPosition.Servertime;
                                tcPosition.Devicetime = getLastPosition.Devicetime;
                                tcPosition.Fixtime = getLastPosition.Fixtime;
                                tcPosition.Valid = getLastPosition.Valid;
                                tcPosition.Latitude = getLastPosition.Latitude;
                                tcPosition.Longitude = getLastPosition.Longitude;
                                tcPosition.Altitude = getLastPosition.Altitude;
                                tcPosition.Speed = getLastPosition.Speed;
                                tcPosition.Course = getLastPosition.Course;
                                tcPosition.Address = getLastPosition.Address;
                                tcPosition.Accuracy = getLastPosition.Accuracy;
                                tcPosition.Network = getLastPosition.Network;
                                tcPosition.Geofenceids = getLastPosition.Geofenceids;
                                //tcPosition.Device = getLastPosition.Device;

                                tcAttribute = JsonConvert.DeserializeObject<TcAttributesView>(getLastPosition.Attributes);
                                tcAttribute.odometer = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                                tcAttribute.totalDistance = tcAttribute.odometer == null ? null : tcAttribute.odometer / 1000;
                                tcAttribute.hours = tcAttribute.hours == null ? null : tcAttribute.hours / 1000 / 60 / 60;

                                tcPositionView.tcPosition = tcPosition;
                                tcPositionView.tcAttribute = tcAttribute;

                                result.Add(tcPositionView);


                            }
                            else
                            {
                                resp.httpCode = Constants.httpCode200;
                                resp.status = Constants.statusError;
                                resp.statusCode = Constants.statusCodeDataNotFound;
                                resp.message = Constants.recordDataNotFound;
                            }
                        }
                        else
                        {
                            resp.httpCode = Constants.httpCode200;
                            resp.status = Constants.statusError;
                            resp.statusCode = Constants.statusCodeDataNotFound;
                            resp.message = Constants.recordDataNotFound;
                        }
                    }

                    resp.httpCode = Constants.httpCode200;
                    resp.status = Constants.statusSuccess;
                    resp.statusCode = Constants.statusCodeOK;
                    resp.data = result;
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

