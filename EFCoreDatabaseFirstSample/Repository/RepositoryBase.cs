using EFCoreDatabaseFirstSample.DTOs;
using EFCoreDatabaseFirstSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace EFCoreDatabaseFirstSample.Repository
{
    public abstract class RepositoryBase<TEntity, TDto> : IRepositoryBase<TEntity, TDto> where TEntity: class
    {
        public RepositoryBase() { }
        public BookStoreContext _bookStoreContext { get; set; }

        public RepositoryBase(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public void Add(TEntity value) => _bookStoreContext.Set<TEntity>().Add(value);

        public void Delete(int id)
        {
            if (_bookStoreContext != null)
            {
                if (_bookStoreContext.Set<TEntity>().Count() > 0)
                {
                    var item = _bookStoreContext.Set<TEntity>().Find(id);
                    _bookStoreContext.Set<TEntity>().Remove(item);
                }
            }
        }  

        public IEnumerable<TEntity> GetAll()
        {
            //if(_bookStoreContext == null)
            //{
            //    return Enumerable.Empty<TEntity>();
            //}
            return _bookStoreContext.Set<TEntity>().ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _bookStoreContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _bookStoreContext.SaveChanges();
        }

        public void Update(int id, TEntity value)
        {
            if(_bookStoreContext != null)
            {
                var item = _bookStoreContext.Set<TEntity>().Find(id);
                _bookStoreContext.Entry<TEntity>(item).CurrentValues.SetValues(value);
            }
        }
        public TDto GetDto(long id)
        {
            throw new NotImplementedException();
        }
        public TEntity Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
