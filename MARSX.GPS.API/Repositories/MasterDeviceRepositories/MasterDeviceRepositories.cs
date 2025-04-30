using System.Transactions;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services;
using WatchDog;

namespace MARSX.GPS.API.Repositories.MasterDeviceRepositories
{
    public class MasterDeviceRepositories : IMasterDeviceRepositories
    {
        private readonly TrackerContext _context;

        private readonly MasterDeviceService service;

        private readonly TcDevicesService tcDevicesService;

        public MasterDeviceRepositories()
        {
            _context = new TrackerContext();

            service = new MasterDeviceService(_context);

            tcDevicesService = new TcDevicesService(_context);
        }

        public async Task<Response> Get(MasterDeviceFilter param)
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

        public async Task<Response> Detail(int id)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.Detail(id));
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

        public async Task<Response> Create(MasterDevice param)
        {
            Response resp = new Response();

            try
            {

                resp = await Task.Run(() => tcDevicesService.Create(param));

                if (resp.status == true)
                {
                    resp = await Task.Run(() => service.Create(param));

                    if (resp.status == false)
                    {
                        resp = await Task.Run(() => tcDevicesService.Delete(param));

                        resp.httpCode = Constants.httpCode200;
                        resp.status = Constants.statusError;
                        resp.statusCode = Constants.statusCodeException;
                        resp.type = Constants.msgError;
                        resp.message = Constants.invalidDataDuplicate;
                    }
                }

            }
            catch (Exception ex)
            {
                resp.httpCode = Constants.httpCode500;
                resp.status = Constants.statusError;
                resp.statusCode = Constants.statusCodeException;
                resp.type = Constants.msgError;
                resp.message = Constants.httpCode500Message;
                resp.exception = ex.Message;

                WatchLogger.LogError("Message : " + ex.Message + " | " + "Exception : " + ex.InnerException == null ? "" : ex.InnerException.ToString());
            }

            return resp;
        }

        public async Task<Response> Update(MasterDevice param)
        {
            Response resp = new Response();

            try
            {
                resp = await Task.Run(() => service.Update(param));

                //resp = await Task.Run(() => tcDevicesService.Update(param));

                //if (resp.status == true)
                //{
                //    resp = await Task.Run(() => service.Update(param));
                //}
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

