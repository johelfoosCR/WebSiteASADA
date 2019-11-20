using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAsada.Helpers
{
    public static class ReflectionHelper<T>
    {
        public static T CreateInstance(params object[] parameters)
        {
            return (T)Activator.CreateInstance(typeof(T), parameters);
        } 
    }
}
