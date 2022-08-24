using EFCoreDatabaseFirstSample.DTOs;
using EFCoreDatabaseFirstSample.Models;

namespace EFCoreDatabaseFirstSample.Repository
{
    public class AuthorRepository : RepositoryBase<Author,AuthorDto>, IAuthorRepository
    {
        public AuthorRepository() { }
        public AuthorRepository(BookStoreContext bookStoreContext)
            : base(bookStoreContext)
        {
        }
        //public IEnumerable<Author> GetAll()
        //{
        //    return _bookStoreContext.Authors.ToList();
        //}
        public Author Get(int id)
        {
            _bookStoreContext.ChangeTracker.LazyLoadingEnabled = true;
            var author  = _bookStoreContext.Authors.FirstOrDefault(s => s.Id == id);
            if (author == null)
            {
                return null;
            }
            _bookStoreContext.Entry(author)
                .Reference(b => b.AuthorContact)
                .Load();
            _bookStoreContext.Entry(author)
                    .Collection(b => b.Books)
                    .Load();

            return author;

        }

        public AuthorDto GetDto(int id)
        {
            //_bookStoreContext.ChangeTracker.LazyLoadingEnabled = true;
            //using(var context = new BookStoreContext())
            //{
            //    var author = context.Authors.FirstOrDefault(s => s.Id == id);
            //    return AuthorDtoMapper.MapToDto(author);
            //}
            throw new NotImplementedException();
        }


        //public void Add(Author author)
        //{
        //    _bookStoreContext.Authors.Add(author);
        //}

        //public void Update(int id, Author value)
        //{
        //    var author = _bookStoreContext.Authors.Find(id);
        //    _bookStoreContext.Entry<Author>(author).CurrentValues.SetValues(value);
        //}

        //public void Delete(int id)
        //{
        //    var author = _bookStoreContext.Authors.Find(id);
        //    _bookStoreContext.Authors.Remove(author);
        //}

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            _bookStoreContext.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public class AuthorDto
        //{
        //    _bookStoreContext.Change
        //}
    }

    
}
