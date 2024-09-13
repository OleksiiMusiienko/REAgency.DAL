using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.OtherRepository
{
    public class OrderRepository: IOrdered
    {
        private REAgencyContext db;

        public OrderRepository(REAgencyContext context)
        {
            this.db = context;
        }

        public async Task Create(Order order)
        {
            await db.Orders.AddAsync(order);
        }

        public async Task Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Order? order = await db.Orders.FindAsync(id);
            if (order != null)
                db.Orders.Remove(order);
        }

        public async Task<Order> Get(int id)
        {
            var orders = await db.Orders.Include(p=>p.objectsForOrders).Where(a => a.Id == id).ToListAsync();
            Order? order = orders.FirstOrDefault();
            return order!;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = db.Orders.Include(o=>o.objectsForOrders).ToList();
            return orders; 
        }
    }
}
