using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookCategoryService
    {
        IDataResult<List<BookCategory>> GetAll();
        IDataResult<BookCategory> GetById(int id);
        IResult Add(BookCategory bookCategory);
        IResult Update(BookCategory bookCategory);
        IResult Delete(BookCategory bookCategory);
    }
}
