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
            return await db.Steads.Include(o => o.estateObject).ToListAsync();
        }

        public async Task<Stead> Get(int id)
        {
            var steads = await db.Steads.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Stead? st = steads.FirstOrDefault();
            return st!;
        }

        public async Task<Stead> GetByEstateObjectId(int id)
        {
            var steads = await db.Steads.Include(o => o.estateObject).Where(a => a.estateObjectId == id).ToListAsync();
            Stead? s = steads?.FirstOrDefault();
            return s!;

        }
        public async Task Create(Stead st)
        {
            await db.Steads.AddAsync(st);
        }
        public void Update(Stead st)
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
