using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookCategoryManager : IBookCategoryService
    {
        IBookCategoryDal _bookCategoryDal;

        public BookCategoryManager(IBookCategoryDal bookCategoryDal)
        {
            _bookCategoryDal = bookCategoryDal;
        }

        public IResult Add(BookCategory bookCategory)
        {
            _bookCategoryDal.Add(bookCategory);
            return new SuccessResult("Category added");
        }

        public IResult Delete(BookCategory bookCategory)
        {
            _bookCategoryDal.Delete(bookCategory);
            return new SuccessResult("Category Deleted");
        }

        public IDataResult<List<BookCategory>> GetAll()
        {
            var categories= _bookCategoryDal.GetAll();
            return new SuccessDataResult<List<BookCategory>>(categories);
        }

        public IDataResult<BookCategory> GetById(int id)
        {
            var category = _bookCategoryDal.Get(c => c.Id == id);
            return new SuccessDataResult<BookCategory>(category);
        }

        public IResult Update(BookCategory bookCategory)
        {
            _bookCategoryDal.Update(bookCategory);
            return new SuccessResult();
        }
    }
}
