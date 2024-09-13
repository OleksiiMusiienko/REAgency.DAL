using REAgency.DAL.Entities;

namespace REAgency.DAL.Interfaces
{
    public interface IOrdered
    {
        Task Create(Order clientOrder);
        Task Update(Order clientOrder);
        Task Delete(int id);
        Task<Order> Get(int id);
        Task<IEnumerable<Order>> GetAll();
    }
}
