using EFCoreDatabaseFirstSample.DTOs;

namespace EFCoreDatabaseFirstSample.Repository
{
    public interface IAuthorRepository : IRepositoryBase<Author,AuthorDto>, IDisposable
    {
        IEnumerable<Author> GetAll();
        Author Get(int id);

        AuthorDto GetDto(int id);
        void Add(Author author);
        void Delete(int id);
        void Update(int id, Author author);
    }
}
