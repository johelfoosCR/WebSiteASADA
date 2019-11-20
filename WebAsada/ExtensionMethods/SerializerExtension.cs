using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAsada
{
    public static class SerializerExtension
    { 
        public static string Serialize<T>(this T self) where T : class
        {
            return JsonConvert.SerializeObject(self);
        } 
    }
}
