using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;
using System.Numerics;

namespace REAgency.DAL.Repositories.OtherRepository
{
    public class OperationRepository : IElseEntities<Operation>
    {
        private REAgencyContext db;

        public OperationRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Operation>> GetAll()
        {
            return await db.Operations.ToListAsync();
        }
        public async Task<Operation> Get(int id)
        {
            Operation? operation = await db.Operations.FindAsync(id);
            return operation!;
        }
        public async Task<Operation> GetByName(string name)
        {
            var operations = await db.Operations.Where(a => a.Name == name).ToListAsync();
            Operation? operation = operations?.FirstOrDefault();
            return operation!;
        }
    }
}
