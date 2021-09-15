using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<BookForGetAllDto>> GetAll();
        IDataResult<BookForGetByIdDto> GetById(int id);
        IResult Add(BookForAddDto bookForAddDto);
        IResult Update(BookForAddDto bookForUpdateDto);
        IResult Delete(BookForGetByIdDto bookForDeleteDto);
    }
}
