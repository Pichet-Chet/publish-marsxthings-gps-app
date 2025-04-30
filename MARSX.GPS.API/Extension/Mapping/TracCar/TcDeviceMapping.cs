using System.Linq;
using System.Numerics;
using MARSX.GPS.API.Models;
using MARSX.GPS.API.Models.Customs.MarsxTrack;
using Newtonsoft.Json;

namespace MARSX.GPS.API.Extension.Mapping.TracCar
{
    public static class TcDeviceMapping
    {
        
        public static TcDevicesView device(TcDevice param)
        {
            TcDevicesView devices = new TcDevicesView();

            devices.id = param.Id;

            if (!string.IsNullOrEmpty(param.Attributes))
            {
                devices.attributes = JsonConvert.DeserializeObject<TcAttributesView>(param.Attributes);
            }

            devices.groupId = param.Groupid;
            devices.calendarId = param.Calendarid;
            devices.name = param.Name;
            devices.uniqueId = param.Uniqueid;
            devices.status = param.Status;
            devices.lastUpdate = param.Lastupdate;
            devices.positionId = param.Positionid;
            devices.phone = param.Phone;
            devices.model = param.Model;
            devices.contact = param.Contact;
            devices.category = param.Category;
            devices.disabled = param.Disabled;
            devices.expirationTime = param.Expirationtime;

            return devices;

        }

        public static List<TcDevicesView> devices(List<TcDevice> param)
        {
            List<TcDevicesView> devices = new List<TcDevicesView>();

            foreach (var item in param)
            {
                TcDevicesView device = new TcDevicesView();

                device.id = item.Id;

                if (!string.IsNullOrEmpty(item.Attributes))
                {
                    device.attributes = JsonConvert.DeserializeObject<TcAttributesView>(item.Attributes);
                }

                device.groupId = item.Groupid;
                device.calendarId = item.Calendarid;
                device.name = item.Name;
                device.uniqueId = item.Uniqueid;
                device.status = item.Status;
                device.lastUpdate = item.Lastupdate;
                device.positionId = item.Positionid;
                device.phone = item.Phone;
                device.model = item.Model;
                device.contact = item.Contact;
                device.category = item.Category;
                device.disabled = item.Disabled;
                device.expirationTime = item.Expirationtime;

                devices.Add(device);
            }

            return devices;

        }
    }
}

