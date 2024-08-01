using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.LocationsRepository
{
    public class CountryRepository: ILocation<Country>
    {
        private REAgencyContext db;

        public CountryRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await db.Countries.ToListAsync();
        }
        public async Task<Country> Get(int id)
        {
            Country? ctr = await db.Countries.FindAsync(id);
            return ctr!;
        }
        public async Task<Country> GetByName(string name)
        {
            Country? ctr = await db.Countries.FindAsync(name);
            return ctr!;
        }
        public async Task Create(Country ctr)
        {
            await db.Countries.AddAsync(ctr);
        }
        public async void Update(Country ctr)
        {
            db.Entry(ctr).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Country? ctr = await db.Countries.FindAsync(id);
            if (ctr != null)
                db.Countries.Remove(ctr);
        }
    }
}
