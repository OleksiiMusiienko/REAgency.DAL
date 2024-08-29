using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Person;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.PersonRepository
{
    public class ClientRepository : IClient
    {
        private REAgencyContext db;

        public ClientRepository(REAgencyContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await db.Clients.Include(c =>c.Employee).Include(c=>c.Operation).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllByEmployee(int id) // метод выборки клиентов по сотруднику
        {
            return await db.Clients.Include(e => e.Employee).Where(e => e.employeeId == id).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllByOperation(int opId)
        {
            return await db.Clients.Include(o => o.Operation).Where(o => o.operationId == opId).ToListAsync();
        }

        public async Task<Client> Get(int id)
        {
            var clients = await db.Clients.Include(o => o.Operation).Include(o => o.Operation).Where(a => a.Id == id).ToListAsync();
            Client? client = clients?.FirstOrDefault();
            return client;
        }

        public async Task<Client> GetByName(string name)
        {
            var clients = await db.Clients.Where(a => a.Name == name).ToListAsync();
            Client? client = clients?.FirstOrDefault();
            return client;
        }
        public async Task<Client> GetByEmail(string email)
        {
            //Client client = await db.Clients.FirstOrDefaultAsync(e => e.Email == email);
            var clients = await db.Clients.Where(a => a.Email == email).ToListAsync();
            Client? client = clients?.FirstOrDefault();
            return client;
        }
        public async Task Create(Client client)
        {
            await db.Clients.AddAsync(client);
        }

        public void Update(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
        }
        public void UpdatePassword(Client client)
        { 
            var clients= db.Clients.SingleOrDefault(x => x.Id == client.Id);
            clients.Password = client.Password;
            clients.Salt = client.Salt;

            db.SaveChanges();
        }
        public async Task Delete(int id)
        {
            Client? client = await db.Clients.FindAsync(id);
            if (client != null)
                db.Clients.Remove(client);
        }
    }
}
