using BookListRazor.Models;
using BookListRazor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.UnitOfWork
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly GenericRepository<TEntity> _entityRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public GenericRepository<TEntity> EntityRepository
        {
            get
            {
                return _entityRepository ?? new GenericRepository<TEntity>(_context);
            }
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
