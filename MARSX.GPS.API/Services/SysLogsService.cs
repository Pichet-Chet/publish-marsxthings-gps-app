using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Constants;
using MARSX.GPS.API.Models.Filters;
using MARSX.GPS.API.Models.Filters.LongdoMap;
using MARSX.GPS.API.Models.Reponse;
using MARSX.GPS.API.Services.Extension.Longdo;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace MARSX.GPS.API.Services
{
	public class SysLogsService
	{
        private readonly TrackerContext _context;

        private readonly LongdoService longdoService;

        public SysLogsService(TrackerContext context)
        {
            _context = context;

            longdoService = new LongdoService(context);
        }

        public async Task<Response> Create(SysLog param)
        {
            Response resp = new Response();

            try
            {
                LongdoMapFilter longdoMapFilter = new LongdoMapFilter();

                longdoMapFilter.lat = Convert.ToDouble(param.ClientLatitude);
                longdoMapFilter.lon = Convert.ToDouble(param.ClientLongitude);

                param.ClientAddress = await longdoService.rerverseGeocoding(longdoMapFilter);

                await Task.Run(() => _context.SysLogs.AddAsync(param));

                _context.SaveChanges();

                resp.httpCode = Constants.httpCode200;
                resp.status = Constants.statusSuccess;
                resp.statusCode = Constants.statusCodeOK;
                resp.data = param;
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

