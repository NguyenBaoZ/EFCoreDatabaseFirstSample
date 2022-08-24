using EFCoreDatabaseFirstSample.DTOs;
using EFCoreDatabaseFirstSample.Models;
using EFCoreDatabaseFirstSample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreDatabaseFirstSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        public BookStoreContext _bookStoreContext{ get; set; }
        private readonly IRepositoryManager _repositoryManager;
        //private IAuthorRepository authorRepository;

        public AuthorController(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        // GET: /<AuthorController>
        [HttpGet]
        public IEnumerable<AuthorDto> Get()
        {

            var authors = _repositoryManager.AuthorRepository.GetAll();
            try
            {
                var authorDto = authors.Select(c => new AuthorDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    //AuthorContact = new AuthorContactDto
                    //{
                    //    Address = c.AuthorContact.Address,
                    //    ContactNumber = c.AuthorContact.ContactNumber,
                    //}
                }).ToList();
                return authorDto;

            }
            catch (Exception e)
            {
                throw new NullReferenceException();
            }
        }

        // GET /<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _repositoryManager.AuthorRepository.Get(id);
        }

        // POST /<AuthorController>
        [HttpPost]
        public void Post([FromBody] Author value)
        {
            _repositoryManager.AuthorRepository.Add(value);
            _repositoryManager.Save();
        }

        // PUT /<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author value)
        {
            var author = _repositoryManager.AuthorRepository.Get(id);
            if (author != null)
            {
                _repositoryManager.AuthorRepository.Update(id, value);
            }
            else
            {
                _repositoryManager.AuthorRepository.Add(value);
            }
            _repositoryManager.Save();
        }
        // DELETE /<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repositoryManager.AuthorRepository.Delete(id);
            _repositoryManager.Save();
        }
    }
}
