using REAgency.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.DAL.Interfaces
{
    public interface IOrdered
    {
        Task Create(Order clientOrder);
        void Update(Order clientOrder);
        Task Delete(int id);
        Task<Order> Get(int id);
        Task<IEnumerable<Order>> GetAll();
    }
}
