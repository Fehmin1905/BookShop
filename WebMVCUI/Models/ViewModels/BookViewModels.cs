using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVCUI.Models.ViewModels
{
    public class BookViewModels
    {
        public static BookForAddDto BookForAddDtos { get; set; }
        public List<BookForGetAllDto> BookForGetAllDtos { get; set; }
        public BookForGetByIdDto BookForGetByIdDto { get; set; }
    }
}
