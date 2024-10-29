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
            return await db.Offices.Include(o => o.estateObject).ToListAsync();
        }
        public async Task<Office> Get(int id)
        {
            var offices = await db.Offices.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Office? of = offices.FirstOrDefault();
            return of!;
        }
        public async Task<Office> GetByEstateObjectId(int id)
        {
            var offices = await db.Offices.Include(o => o.estateObject).Include(o => o.estateObject).Include(c => c.estateObject.Client).
                Include(e => e.estateObject.Employee).Include(o => o.estateObject.Operation).
                Include(l => l.estateObject.Location).Include(s => s.estateObject.Currency).
                Include(s => s.estateObject.unitArea).Include(s => s.estateObject.Location.Locality).
                Include(con => con.estateObject.Location.Country).Include(r => r.estateObject.Location.Region).
                Include(s => s.estateObject.Location.District).Where(a => a.estateObjectId == id).ToListAsync();
            Office? o = offices?.FirstOrDefault();
            return o!;

        }
        public async Task Create(Office of)
        {
            await db.Offices.AddAsync(of);
        }
        public void Update(Office of)
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
