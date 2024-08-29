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
            return await db.Parkings.ToListAsync();
        }
        public async Task<IEnumerable<Parking>> GetAllByEmployee(int id)
        {
            var parkings = await db.Parkings.Where(f => f.employeeId == id).ToListAsync();
            return parkings!;
        }

        public async Task<IEnumerable<Parking>> GetAllByType(int id)
        {
            var parkings = await db.Parkings.Where(p => p.estateTypeId == id).ToListAsync();
            return parkings;
        }
        public async Task<Parking> Get(int id)
        {
            Parking? pr = await db.Parkings.FindAsync(id);
            return pr!;
        }
        public async Task Create(Parking pr)
        {
            await db.Parkings.AddAsync(pr);
        }
        public async void Update(Parking pr)
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
