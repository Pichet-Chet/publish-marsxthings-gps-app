using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;
using Newtonsoft.Json;

namespace MARSX.GPS.APPLICATION.Extension
{
	public static class AppHelper
	{

        public static string GetQueryString<T>(T param)
        {
            string result = "";

            List<string> strings = new List<string>();

            Type type = param.GetType();

            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.GetValue(param) != null)
                {
                    var values = property.Name + "=" + property.GetValue(param);

                    strings.Add(values);
                }
            }

            result = string.Join("&", strings);

            return result;
        }

    }
}

