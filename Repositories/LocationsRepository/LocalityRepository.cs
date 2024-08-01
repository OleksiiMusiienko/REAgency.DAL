using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.LocationsRepository
{
    public class LocalityRepository: ILocation<Locality>
    {
        private REAgencyContext db;

        public LocalityRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Locality>> GetAll()
        {
            return await db.Localities.ToListAsync();
        }
        public async Task<Locality> Get(int id)
        {
            Locality? loc = await db.Localities.FindAsync(id);
            return loc!;
        }
        public async Task<Locality> GetByName(string name)
        {
            Locality? loc = await db.Localities.FindAsync(name);
            return loc!;
        }
        public async Task Create(Locality loc)
        {
            await db.Localities.AddAsync(loc);
        }
        public async void Update(Locality loc)
        {
            db.Entry(loc).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Locality? loc = await db.Localities.FindAsync(id);
            if (loc != null)
                db.Localities.Remove(loc);
        }
    }
}
