using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class GarageRepository: IRepositoryObject<Garage>
    {
        private REAgencyContext db;

        public GarageRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Garage>> GetAll()
        {
            return await db.Garages.ToListAsync();
        }
        public async Task<IEnumerable<Garage>> GetAllByEmployee(int id)
        {
            var gr = await db.Garages.Where(f => f.employeeId == id).ToListAsync();
            return gr;
        }
        public async Task<Garage> Get(int id)
        {
            Garage? gr = await db.Garages.FindAsync(id);
            return gr!;
        }
        public async Task Create(Garage gr)
        {
            await db.Garages.AddAsync(gr);
        }
        public async void Update(Garage gr)
        {
            db.Entry(gr).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Garage? gr = await db.Garages.FindAsync(id);
            if (gr != null)
                db.Garages.Remove(gr);
        }
    }
}
