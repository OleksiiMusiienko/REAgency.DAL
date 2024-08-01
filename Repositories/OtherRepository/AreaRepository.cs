using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.OtherRepository
{
    public class AreaRepository : IElseEntities<Area>
    {
        private REAgencyContext db;

        public AreaRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Area>> GetAll()
        {
            return await db.Areas.ToListAsync();
        }
        public async Task<Area> Get(int id)
        {
            Area? area = await db.Areas.FindAsync(id);
            return area!;
        }
        public async Task<Area> GetByName(string name)
        {
            Area? area = await db.Areas.FindAsync(name);
            return area!;
        }

    }
    
}
