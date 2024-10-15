using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class ParkingRepository: IRepositoryObject<Parking>
    {
        private REAgencyContext db;

        public ParkingRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Parking>> GetAll()
        {
            return await db.Parkings.Include(o => o.estateObject).ToListAsync();
        }
        
        public async Task<Parking> Get(int id)
        {
            var parkings = await db.Parkings.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Parking? pr = parkings.FirstOrDefault();
            return pr!;
        }

        public async Task<Parking> GetByEstateObjectId(int id)
        {
            var parking = await db.Parkings.Include(o => o.estateObject).Include(c => c.estateObject.Client).Include(l => l.estateObject.Location).Where(a => a.estateObjectId == id).ToListAsync();
            Parking? p = parking?.FirstOrDefault();
            return p!;

        }
        public async Task Create(Parking pr)
        {
            await db.Parkings.AddAsync(pr);
        }
        public void Update(Parking pr)
        {
            db.Entry(pr).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Parking? pr = await db.Parkings.FindAsync(id);
            if (pr != null)
                db.Parkings.Remove(pr);
        }
    }
}
