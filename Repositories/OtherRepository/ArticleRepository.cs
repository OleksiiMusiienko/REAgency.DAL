using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.OtherRepository
{
    public class ArticleRepository: IArticle
    {
        private REAgencyContext db;

        public ArticleRepository(REAgencyContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await db.Articles.Include(c => c.Employee).ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetAllByEmployee(int id) // метод выборки статей по сотруднику
        {
            return await db.Articles.Include(e => e.Employee).Where(e => e.employeeId == id).ToListAsync();
        }

        public async Task<Article> Get(int id)
        {
            var aticles = await db.Articles.Where(a => a.Id == id).ToListAsync();
            Article? aticle = aticles.FirstOrDefault();
            return aticle!;
        }

        public async Task Create(Article at)
        {
            await db.Articles.AddAsync(at);
        }

        public void Update(Article at)
        {
            db.Entry(at).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Article? at = await db.Articles.FindAsync(id);
            if (at != null)
                db.Articles.Remove(at);
        }
    }
}

