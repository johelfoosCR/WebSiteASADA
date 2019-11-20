using AutoMapper;
using System;
using System.Collections.Generic;
using WebAsada.BaseObjects;

namespace WebAsada.Helpers
{
    public static class MapperHelper<T,V>
    {
        public static V MapEntity(MapperConfiguration mapperConfiguration ,T entity)
        {
            return mapperConfiguration.CreateMapper().Map<T, V>(entity);
        }

        public static IEnumerable<V> MapEnumerable(MapperConfiguration mapperConfiguration,IEnumerable<T> entityList)
        {
            return mapperConfiguration.CreateMapper().Map<IEnumerable<T>, List<V>>(entityList);
        }
         
         
    }
}
