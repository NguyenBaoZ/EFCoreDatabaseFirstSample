namespace EFCoreDatabaseFirstSample.Repository
{
    public interface IRepositoryBase<TEntity, TDto>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TDto GetDto(long id);

        void Add(TEntity value);
        void Delete(int id);
        void Update(int id, TEntity value);
        
        void Save();
    }
}
