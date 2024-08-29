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
            return await db.Rooms.ToListAsync();
        }
        public async Task<IEnumerable<Room>> GetAllByEmployee(int id)
        {
            var rooms = await db.Rooms.Where(f => f.employeeId == id).ToListAsync();
            return rooms!;
        }
        public async Task<IEnumerable<Room>> GetAllByType(int id)
        {
            var room = await db.Rooms.Where(r => r.estateTypeId == id).ToListAsync();
            return room;
        }
        public async Task<Room> Get(int id)
        {
            Room? rm = await db.Rooms.FindAsync(id);
            return rm!;
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
