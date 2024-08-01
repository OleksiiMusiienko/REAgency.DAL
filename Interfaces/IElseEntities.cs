namespace REAgency.DAL.Interfaces
{
    public interface IElseEntities<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> GetByName(string name);
    }
}
