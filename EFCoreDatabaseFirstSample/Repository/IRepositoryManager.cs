namespace EFCoreDatabaseFirstSample.Repository
{
    public interface IRepositoryManager
    {
        IAuthorRepository AuthorRepository { get; }

        void Save();
    }
}
