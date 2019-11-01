using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestWebApi.Tools
{
    internal static class JsonExtension
    {
        public static T To<T>(this string jsonString, JsonSerializerSettings settings = null)
        {
            if (settings == null) settings = new JsonSerializerSettings();
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString, settings);

            }
            catch
            {
                return default(T);
            }
        }
        public static string ToJsonString(this object obj, JsonSerializerSettings settings = null)
        {
            if (settings == null) settings = new JsonSerializerSettings();
            try
            {
                return JsonConvert.SerializeObject(obj, settings);

            }
            catch
            {
                return "";
            }
        }
    }
}
