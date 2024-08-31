using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using System.Numerics;


namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class FlatRepository: IRepositoryObject<Flat>
    {
        private REAgencyContext db;

        public FlatRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Flat>> GetAll()
        {
            return await db.Flats.Include(o => o.estateObject).ToListAsync();
        }

        public async Task<Flat> Get(int id)     
        {
            var flats = await db.Flats.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Flat? fl = flats?.FirstOrDefault();
            return fl!;
        }
        public async Task Create(Flat fl)
        {
            await db.Flats.AddAsync(fl);
        }
        public async void Update(Flat fl)
        {
           db.Entry(fl).State = EntityState.Modified; 
        }
        public async Task Delete(int id)
        {
            Flat? fl = await db.Flats.FindAsync(id);
            if (fl != null)
                db.Flats.Remove(fl);
        }
    }
}
