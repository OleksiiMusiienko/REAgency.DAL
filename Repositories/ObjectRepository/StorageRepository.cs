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
            return await db.Storages.ToListAsync();
        }
        public async Task<IEnumerable<Storage>> GetAllByEmployee(int id)
        {
            var stor = await db.Storages.Where(f => f.employeeId == id).ToListAsync();
            return stor!;
        }
        public async Task<IEnumerable<Storage>> GetAllByType(int id)
        {
            var storages = await db.Storages.Where(s => s.estateTypeId == id).ToListAsync();
            return storages;
        }
        public async Task<Storage> Get(int id)
        {
            Storage? stor = await db.Storages.FindAsync(id);
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
