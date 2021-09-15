using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IBookDal BookDal { get; }
        IBookCategoryDal BookCategoryDal { get; }

        void Commit();
    }
}
