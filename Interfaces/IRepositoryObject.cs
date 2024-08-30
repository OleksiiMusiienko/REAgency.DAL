namespace REAgency.DAL.Interfaces
{
    public interface IRepositoryObject<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        void Update(T item);
        Task Delete(int id);

    }
}
