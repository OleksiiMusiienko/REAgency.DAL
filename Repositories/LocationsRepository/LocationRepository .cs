using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.LocationsRepository
{
    public class LocationRepository: ILocation<Location>
    {
        private REAgencyContext db;

        public LocationRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Location>> GetAll()
        {
            return await db.Locations.ToListAsync();
        }
        public async Task<Location> Get(int id)
        {
            Location? loc = await db.Locations.FindAsync(id);
            return loc!;
        }
        public async Task<Location> GetByName(string name)
        {
            Location? loc = await db.Locations.FindAsync(name);
            return loc!;
        }
        public async Task Create(Location loc)
        {
            await db.Locations.AddAsync(loc);
        }
        public async void Update(Location loc)
        {
            db.Entry(loc).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Location? loc = await db.Locations.FindAsync(id);
            if (loc != null)
                db.Locations.Remove(loc);
        }
        public async Task<Location> GetByDateTime(DateTime date)
        {
            var locations = await db.Locations.Where(f => f.Date == date).ToListAsync();
            Location? location = locations.FirstOrDefault();
            return location!;
        }
    }
}
