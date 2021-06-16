using System;
using AutoMapper;

namespace ConsoleAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });
            IMapper mapper = config.CreateMapper();
            var source = new AuthorModel { Id = 123, FirstName = "Shuhua", LastName = "Gao" };
            var dest = mapper.Map<AuthorDTO>(source);
            Console.WriteLine(dest.FullName);
        }
    }
}
