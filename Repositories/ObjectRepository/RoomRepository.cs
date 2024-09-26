using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class RoomRepository: IRepositoryObject<Room>
    {
        private REAgencyContext db;

        public RoomRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Room>> GetAll()
        {
            return await db.Rooms.Include(o => o.estateObject).ToListAsync();
        }
        public async Task<Room> Get(int id)
        {
            var rooms = await db.Rooms.Include(o => o.estateObject).Where(a => a.Id == id).ToListAsync();
            Room? rm = rooms.FirstOrDefault();
            return rm!;
        }

        public async Task<Room> GetByEstateObjectId(int id)
        {
            var rooms = await db.Rooms.Include(o => o.estateObject).Where(a => a.estateObjectId == id).ToListAsync();
            Room? r = rooms?.FirstOrDefault();
            return r!;

        }
        public async Task Create(Room rm)
        {
            await db.Rooms.AddAsync(rm);
        }
        public async void Update(Room rm)
        {
            db.Entry(rm).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Room? rm = await db.Rooms.FindAsync(id);
            if (rm != null)
                db.Rooms.Remove(rm);
        }
    }
}
