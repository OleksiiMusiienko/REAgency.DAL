using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class StorageRepository: IRepositoryObject<Storage>
    {
        private REAgencyContext db;

        public StorageRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Storage>> GetAll()
        {
            return await db.Storages.Include(o => o.estateObject).ToListAsync();
        }
        
        public async Task<Storage> Get(int id)
        {
            var storages = await db.Storages.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Storage? stor = storages.FirstOrDefault();
            return stor!;
        }

        public async Task<Storage> GetByEstateObjectId(int id)
        {
            var storeges = await db.Storages.Include(o => o.estateObject).Include(o => o.estateObject).Include(c => c.estateObject.Client).
                Include(e => e.estateObject.Employee).Include(o => o.estateObject.Operation).
                Include(l => l.estateObject.Location).Include(s => s.estateObject.Currency).
                Include(s => s.estateObject.unitArea).Include(s => s.estateObject.Location.Locality).
                Include(con => con.estateObject.Location.Country).Include(r => r.estateObject.Location.Region).
                Include(s => s.estateObject.Location.District).Where(a => a.estateObjectId == id).ToListAsync();
            Storage? s = storeges?.FirstOrDefault();
            return s!;

        }
        public async Task Create(Storage stor)
        {
            await db.Storages.AddAsync(stor);
        }
        public void Update(Storage stor)
        {
            db.Entry(stor).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Storage? stor = await db.Storages.FindAsync(id);
            if (stor != null)
                db.Storages.Remove(stor);
        }
    }
}
