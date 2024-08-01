using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.LocationsRepository
{
    public class DistrictRepository: ILocation<District>
    {
        private REAgencyContext db;

        public DistrictRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<District>> GetAll()
        {
            return await db.Districts.ToListAsync();
        }
        public async Task<District> Get(int id)
        {
            District? dist = await db.Districts.FindAsync(id);
            return dist!;
        }
        public async Task<District> GetByName(string name)
        {
            District? dist = await db.Districts.FindAsync(name);
            return dist!;
        }
        public async Task Create(District dist)
        {
            await db.Districts.AddAsync(dist);
        }
        public async void Update(District dist)
        {
            db.Entry(dist).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            District? dist = await db.Districts.FindAsync(id);
            if (dist != null)
                db.Districts.Remove(dist);
        }
    }
}
