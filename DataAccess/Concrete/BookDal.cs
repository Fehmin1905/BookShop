using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BookDal:EfEntityRepositoryBase<Book,BookDbContext>,IBookDal
    {
        //BookDbContext _context;
        //public BookDal(BookDbContext context) : base(context)
        //{
        //    _context = context;
        //}
    }
}
