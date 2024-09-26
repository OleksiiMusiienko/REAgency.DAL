using REAgency.DAL.Entities.Locations;

namespace REAgency.DAL.Interfaces
{
    public interface ILocation<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> GetByName(string name);
        Task Create(T item);
        void Update(T item);
        Task Delete(int id);
        Task<Location> GetByDateTime(DateTime date);
    }
}
