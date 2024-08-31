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
        public async Task Create(Storage stor)
        {
            await db.Storages.AddAsync(stor);
        }
        public async void Update(Storage stor)
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
