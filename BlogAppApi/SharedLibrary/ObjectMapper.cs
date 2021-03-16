using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.SharedLibrary
{
    public static class ObjectMapper
    {
        //Sadece çağrıldığında çalışacak.
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DtoMapper>();
            });
            return configuration.CreateMapper();
        });
        //çağırılması için gerekli kod.
        public static IMapper Mapper => lazy.Value;
    }
}
