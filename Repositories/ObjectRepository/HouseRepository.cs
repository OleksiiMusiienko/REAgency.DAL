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
        public async Task Create(House hs)
        {
            await db.Houses.AddAsync(hs);
        }
        public async void Update(House hs)
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
