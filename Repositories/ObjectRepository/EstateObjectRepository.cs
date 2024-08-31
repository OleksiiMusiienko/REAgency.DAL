using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class EstateObjectRepository : IRepositoryObject<EstateObject>
    {
        private REAgencyContext db;

        public EstateObjectRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<EstateObject>> GetAll()
        {
            return await db.EstateObjects.ToListAsync();
        }
        public async Task<IEnumerable<EstateObject>> GetAllByEmployee(int id)
        {
            var estateObjects = await db.EstateObjects.Where(f => f.employeeId == id).ToListAsync();
            return estateObjects;
        }

        public async Task<EstateObject> Get(int id)
        {
            EstateObject? obj = await db.EstateObjects.FindAsync(id);
            return obj!;
        }
        public async Task Create(EstateObject obj)
        {
            await db.EstateObjects.AddAsync(obj);
        }
        public async void Update(EstateObject obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            EstateObject? obj = await db.EstateObjects.FindAsync(id);
            if (obj != null)
                db.EstateObjects.Remove(obj);
        }
    }
}
