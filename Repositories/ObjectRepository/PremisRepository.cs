using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class PremisRepository: IRepositoryObject<Premis>
    {
        private REAgencyContext db;

        public PremisRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Premis>> GetAll()
        {
            return await db.Premises.Include(o => o.estateObject).ToListAsync();
        }
        public async Task<Premis> Get(int id)
        {
            var premises = await db.Premises.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Premis? prms = premises.FirstOrDefault();
            return prms!;
        }

        public async Task<Premis> GetByEstateObjectId(int id)
        {
            var premises = await db.Premises.Include(o => o.estateObject).Where(a => a.estateObjectId == id).ToListAsync();
            Premis? p = premises?.FirstOrDefault();
            return p!;

        }
        public async Task Create(Premis prms)
        {
            await db.Premises.AddAsync(prms);
        }
        public async void Update(Premis prms)
        {
            db.Entry(prms).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Premis? prms = await db.Premises.FindAsync(id);
            if (prms != null)
                db.Premises.Remove(prms);
        }
    }
    
}
