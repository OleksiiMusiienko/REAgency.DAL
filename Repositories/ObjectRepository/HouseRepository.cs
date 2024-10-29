using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class HouseRepository: IRepositoryObject<House>
    {
        private REAgencyContext db;

        public HouseRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<House>> GetAll()
        {
            return await db.Houses.Include(o => o.estateObject).ToListAsync();
        }
        
        public async Task<House> Get(int id)
        {
            var houses = await db.Houses.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            House? hs = houses.FirstOrDefault();
            return hs!;
        }
        public async Task<House> GetByEstateObjectId(int id)
        {
            var houses = await db.Houses.Include(o => o.estateObject).Include(c => c.estateObject.Client).
                Include(e => e.estateObject.Employee).Include(o => o.estateObject.Operation).
                Include(l => l.estateObject.Location).Include(s => s.estateObject.Currency).
                Include(s => s.estateObject.unitArea).Include(s => s.estateObject.Location.Locality).
                Include(con => con.estateObject.Location.Country).Include(r => r.estateObject.Location.Region).
                Include(s => s.estateObject.Location.District).Where(a => a.estateObjectId == id).ToListAsync();
            House? h = houses?.FirstOrDefault();
            return h!;

        }
        public async Task Create(House hs)
        {
            await db.Houses.AddAsync(hs);
        }
        public void Update(House hs)
        {
            db.Entry(hs).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            House? hs = await db.Houses.FindAsync(id);
            if (hs != null)
                db.Houses.Remove(hs);
        }
    }
}
