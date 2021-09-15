using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager:IBookService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IBookDal _bookDal;
        public BookManager(IUnitOfWork unitOfWork, IMapper mapper, IBookDal bookDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookDal = bookDal;
        }

        [ValidationAspect(typeof(BookValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Add(BookForAddDto bookForAddDto)
        {
            IResult result = BusinessRules.Run(CheckIfBookCategoryNumberValid(bookForAddDto.BookCategoryId));
            if (result!=null)
            {
                return result;
            }
            var mappedBook = _mapper.Map<Book>(bookForAddDto);
            _bookDal.Add(mappedBook);
            //_unitOfWork.Commit();
            return new SuccessResult("Book added");
        }


        [CacheRemoveAspect("IBookService.Get")]
        public IResult Delete(BookForGetByIdDto bookForDeleteDto)
        {
            //_bookDal.Delete(book);
            var mappedBook = _mapper.Map<Book>(bookForDeleteDto);
            //_bookDal.Delete(mappedBook);
            _unitOfWork.BookDal.Delete(mappedBook);
            return new SuccessResult("Book deleted");
        }

        //[PerformanceAspect(20)]
        [CacheAspect]
        public IDataResult<List<BookForGetAllDto>> GetAll()
        {
            //var books = _unitOfWork.BookDal.GetAll();
            var books = _bookDal.GetAll();

            var mappedBooks = _mapper.Map<List<BookForGetAllDto>>(books);
            return new SuccessDataResult<List<BookForGetAllDto>>(mappedBooks,"Books listed");
        }

        public IDataResult<BookForGetByIdDto> GetById(int id)
        {
            var book = _bookDal.Get(b => b.Id == id);
            var mappedBook = _mapper.Map<BookForGetByIdDto>(book);
            return new SuccessDataResult<BookForGetByIdDto>(mappedBook);
        }

        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Update(BookForAddDto bookForUpdateDto)
        {
            var mappedBook = _mapper.Map<Book>(bookForUpdateDto);
            _bookDal.Update(mappedBook);

            //_unitOfWork.BookDal.Update(mappedBook);
            //_unitOfWork.Commit();
            return new SuccessResult("Modified");
        }


        //---------------------------------------


        private IResult CheckIfBookCategoryNumberValid(int categoryId)
        {
            var result = _bookDal.GetAll(b=>b.BookCategoryId==categoryId).Count;
            if (result < 15)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.BookCategoryLimitExceeded);
        }
    }
}
