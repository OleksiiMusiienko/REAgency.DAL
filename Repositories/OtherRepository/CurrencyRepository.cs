using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.OtherRepository
{
    public class CurrencyRepository : IElseEntities<Currency>
    {
        private REAgencyContext db;

        public CurrencyRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Currency>> GetAll()
        {
            return await db.Currencies.ToListAsync();
        }
        public async Task<Currency> Get(int id)
        {
            Currency? currency = await db.Currencies.FindAsync(id);
            return currency!;
        }
        public async Task<Currency> GetByName(string name)
        {
            Currency? currency = await db.Currencies.FindAsync(name);
            return currency!;
        }
    }

}
