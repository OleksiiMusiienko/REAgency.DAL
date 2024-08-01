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
            return await db.Premises.ToListAsync();
        }
        public async Task<IEnumerable<Premis>> GetAllByEmployee(int id)
        {
            var prms = await db.Premises.Where(f => f.employeeId == id).ToListAsync();
            return prms!;
        }
        public async Task<Premis> Get(int id)
        {
            Premis? prms = await db.Premises.FindAsync(id);
            return prms!;
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
