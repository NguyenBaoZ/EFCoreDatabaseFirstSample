using Microsoft.AspNetCore.Mvc;


namespace EFCoreDatabaseFirstSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private BookStoreContext _bookStoreContext;

        public BookController(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        // GET: /<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookStoreContext.Books;
        }

        // GET /<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _bookStoreContext.Books.FirstOrDefault(s => s.Id == id);
        }

        // POST /<BookController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            _bookStoreContext.Books.Add(value);
            _bookStoreContext.SaveChanges();
        }

        // PUT /<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            var book = _bookStoreContext.Books.FirstOrDefault(s => s.Id == id);
            if (book != null)
            {
                _bookStoreContext.Entry<Book>(book).CurrentValues.SetValues(value);
                _bookStoreContext.SaveChanges();
            }
        }

        // DELETE /<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book = _bookStoreContext.Books.FirstOrDefault(s => s.Id == id);
            if (book != null)
            {
                _bookStoreContext.Books.Remove(book);
                _bookStoreContext.SaveChanges();
            }
        }
    }
}