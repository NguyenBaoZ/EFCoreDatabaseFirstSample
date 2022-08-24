namespace EFCoreDatabaseFirstSample.Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        public BookStoreContext _bookStoreContext { get; set; }
        public IAuthorRepository _authorRepository;

        public RepositoryManager() {
            _bookStoreContext = new BookStoreContext();
        }
        public RepositoryManager(BookStoreContext bookStoreContext, IAuthorRepository authorRepository) : this(bookStoreContext)
        {
            _authorRepository = authorRepository;
        }

        public RepositoryManager(BookStoreContext bookStoreContext)
        {

            _bookStoreContext = bookStoreContext;
        }
        public IAuthorRepository AuthorRepository
        {
            get {
                if (_authorRepository == null)
                    _authorRepository = new AuthorRepository(_bookStoreContext);
                return _authorRepository; 
            }
        }
        public void Save()
        {
            if (_bookStoreContext != null)
            {
                _bookStoreContext.SaveChanges();
            }
        }
    }
}
