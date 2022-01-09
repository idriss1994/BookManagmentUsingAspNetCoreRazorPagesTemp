using BookListRazor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.UnitOfWork
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        GenericRepository<TEntity> EntityRepository { get; }
        void Save();
    }
}
