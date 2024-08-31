using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.OtherRepository
{
    //public class EstateTypeRepository : IElseEntities<EstateType>
    //{
    //    private REAgencyContext db;

    //    public EstateTypeRepository(REAgencyContext context)
    //    {
    //        this.db = context;
    //    }
    //    public async Task<IEnumerable<EstateType>> GetAll()
    //    {
    //        return await db.EstateTypes.ToListAsync();
    //    }
    //    public async Task<EstateType> Get(int id)
    //    {
    //        EstateType? estateType = await db.EstateTypes.FindAsync(id);
    //        return estateType!;
    //    }
    //    public async Task<EstateType> GetByName(string name)
    //    {
    //        EstateType? estateType = await db.EstateTypes.FirstOrDefaultAsync(e => e.Name == name);
    //        return estateType!;
    //    }
    //}
}
