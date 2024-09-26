using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.LocationsRepository
{
    public class RegionRepository: ILocation<Region>
    {
        private REAgencyContext db;

        public RegionRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Region>> GetAll()
        {
            return await db.Regions.ToListAsync();
        }
        public async Task<Region> Get(int id)
        {
            Region? reg = await db.Regions.FindAsync(id);
            return reg!;
        }
        public async Task<Region> GetByName(string name)
        {
            Region? reg = await db.Regions.FindAsync(name);
            return reg!;
        }
        public async Task Create(Region reg)
        {
            await db.Regions.AddAsync(reg);
        }
        public async void Update(Region reg)
        {
            db.Entry(reg).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Region? reg = await db.Regions.FindAsync(id);
            if (reg != null)
                db.Regions.Remove(reg);
        }
        public async Task<Location> GetByDateTime(DateTime date)
        {
            return null;
        }
    }
}
