using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Agrovision.Helpers
{
    public static class TypeMapper
    {
        public static TDestination MapSingle<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();

            });

            var mapper = config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapSingle<TSource, TDestination>(TSource source, TDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map(source, destination);
        }

        public static TDestination MapSingleSkipNullOrEmpty<TSource, TDestination>(TSource source, TDestination destination)
        {
          
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();

                cfg.ShouldMapProperty = (prop) => {
                    var sourceProp = source.GetType().GetProperty(prop.Name);
                    if (sourceProp == null)
                    {
                        return false;
                    }
                    var propertyValue = sourceProp.GetValue(source);
                    var isNullOrEmpty = (propertyValue == null || (sourceProp.PropertyType == typeof(string) && string.IsNullOrEmpty((string)propertyValue)));
                    return !isNullOrEmpty;
                };
            });

            var mapper = config.CreateMapper();
            return mapper.Map(source, destination);
        }

        public static List<TDestination> MapMany<TSource, TDestination>(List<TSource> sourceList)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            return sourceList.Select(MapSingle<TSource, TDestination>).ToList();
        }

        public static TDestination GetNewPopulatedObject<TSource, TDestination>(TSource sourceObject)
           where TDestination : new()
        {
            var newObject = new TDestination();
            MapSingle(sourceObject, newObject);
            return newObject;
        }
    }
}