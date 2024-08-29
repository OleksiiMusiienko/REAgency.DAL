using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class SteadRepository: IRepositoryObject<Stead>
    {
        private REAgencyContext db;

        public SteadRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Stead>> GetAll()
        {
            return await db.Steads.ToListAsync();
        }
        public async Task<IEnumerable<Stead>> GetAllByEmployee(int id)
        {
            var steads = await db.Steads.Where(f => f.employeeId == id).ToListAsync();
            return steads!;
        }
        public async Task<IEnumerable<Stead>> GetAllByType(int id)
        {
            var steads = await db.Steads.Where(s => s.estateTypeId == id).ToListAsync();
            return steads;
        }
        public async Task<Stead> Get(int id)
        {
            Stead? st = await db.Steads.FindAsync(id);
            return st!;
        }
        public async Task Create(Stead st)
        {
            await db.Steads.AddAsync(st);
        }
        public async void Update(Stead st)
        {
            db.Entry(st).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Stead? st = await db.Steads.FindAsync(id);
            if (st != null)
                db.Steads.Remove(st);
        }
    }
}
