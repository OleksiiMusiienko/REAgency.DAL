using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class OfficeRepository: IRepositoryObject<Office>
    {
        private REAgencyContext db;

        public OfficeRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Office>> GetAll()
        {
            return await db.Offices.ToListAsync();
        }
        public async Task<IEnumerable<Office>> GetAllByEmployee(int id)
        {
            var of = await db.Offices.Where(f => f.employeeId == id).ToListAsync();
            return of!;
        }
        public async Task<IEnumerable<Office>> GetAllByType(int id)
        {
            var officies = await db.Offices.Where(o => o.estateTypeId == id).ToListAsync();
            return officies;
        }
        public async Task<Office> Get(int id)
        {
            Office? of = await db.Offices.FindAsync(id);
            return of!;
        }
        public async Task Create(Office of)
        {
            await db.Offices.AddAsync(of);
        }
        public async void Update(Office of)
        {
            db.Entry(of).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Office? of = await db.Offices.FindAsync(id);
            if (of != null)
                db.Offices.Remove(of);
        }
    }
}
