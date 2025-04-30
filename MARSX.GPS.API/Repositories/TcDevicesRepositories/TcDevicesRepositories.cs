using System;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters.TrackCar;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Models.Customs.MarsxTrack;
using MARSX.GPS.API.Services;
using Microsoft.EntityFrameworkCore;
using MARSX.GPS.API.Repositories.TcDevices;
using WatchDog;
using MySqlX.XDevAPI.Common;
using System.Diagnostics;

namespace MARSX.GPS.API.Repositories.TcDevices
{
    public class TcDevicesRepositories : ITcDevicesRepositories
    {
        private readonly TrackerContext _context;

        private readonly TcDevicesService service;

        public TcDevicesRepositories()
        {
            _context = new TrackerContext();

            service = new TcDevicesService(_context);
        }

        public async Task<Response> Get(DevicesFilter param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.Get(param));
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
        public async Task<Response> DevicesByModel(string model)
        {
            Response resp = new Response();

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                resp.data = await service.DevicesByModel(model);

                watch.Stop();

                resp.httpCode = Constants.httpCode200;
                resp.status = Constants.statusSuccess;
                resp.responseTime = watch.Elapsed.TotalSeconds.ToString("N2") + " " + Constants.unitOfTime;
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
        public async Task<Response> DevicesByGroup(int id)
        {
            Response resp = new Response();

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                resp.data = await service.DevicesByGroup(id);

                watch.Stop();

                resp.httpCode = Constants.httpCode200;
                resp.status = Constants.statusSuccess;
                resp.responseTime = watch.Elapsed.TotalSeconds.ToString("N2") + " " + Constants.unitOfTime;
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

