using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class GarageRepository: IRepositoryObject<Garage>
    {
        private REAgencyContext db;

        public GarageRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Garage>> GetAll()
        {
            return await db.Garages.Include(o => o.estateObject).ToListAsync();
        }
        
        public async Task<Garage> Get(int id)
        {
            var garage = await db.Garages.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Garage? gr = garage?.FirstOrDefault();
            return gr!;
        }

        public async Task<Garage> GetByEstateObjectId(int id)
        {
            var garages = await db.Garages.Include(o => o.estateObject).Where(a => a.estateObjectId == id).ToListAsync();
            Garage? g = garages?.FirstOrDefault();
            return g!;

        }
        public async Task Create(Garage gr)
        {
            await db.Garages.AddAsync(gr);
        }
        public void Update(Garage gr)
        {
            db.Entry(gr).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Garage? gr = await db.Garages.FindAsync(id);
            if (gr != null)
                db.Garages.Remove(gr);
        }
    }
}
