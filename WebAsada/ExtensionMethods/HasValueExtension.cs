using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAsada
{
    public static class HasValueExtension 
    {
        public static bool HasValue<T>(this T self) where T : class
        {
            return self != null;
        }
    } 
}
