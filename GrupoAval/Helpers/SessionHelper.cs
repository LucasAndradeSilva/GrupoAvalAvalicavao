using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAval.Helpers {
    public static class SessionHelper {
        public enum SessionKeys
        {
            Alert
        }
        public static T Get<T>(this ISession session, string key = null) {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).FullName;

            var hasValue = session.TryGetValue(key, out byte[] bytes);
            if (hasValue)
            {
                var jsonValue = GetString(bytes);
                var result = JsonConvert.DeserializeObject<T>(jsonValue);
                return result;
            }
            return default(T);
        }
        public static void Remove<T>(this ISession session, string key = null)
        {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).FullName;

            session.Remove(key);            
        }
        public static void Set<T>(this ISession session, T instance, string key = null) {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).FullName;
            session.Set(key, GetBytes(JsonConvert.SerializeObject(instance)));
        }
       
        private static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);
        private static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
    }
    
}