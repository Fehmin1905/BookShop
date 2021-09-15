using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookForAddDto>().ReverseMap();
            CreateMap<Book, BookForGetAllDto>().ReverseMap();
            CreateMap<Book, BookForGetByIdDto>().ReverseMap();
            CreateMap<Book, BookForUpdateDto>().ReverseMap();
        }
    }
}
