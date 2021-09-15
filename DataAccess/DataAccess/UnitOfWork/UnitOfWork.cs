using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        BookDbContext _context;

        public UnitOfWork(BookDbContext context)
        {
            _context = context;
            BookDal = new BookDal();
            BookCategoryDal = new BookCategoryDal();
        }

        public IBookDal BookDal { get; private set; }

        public IBookCategoryDal BookCategoryDal { get; private set; }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
