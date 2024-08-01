using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Person;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.OtherRepository
{
    public class PostRepository: IPost
    {
        private REAgencyContext db;
        public PostRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await db.Posts.ToListAsync();
        }
        public async Task<Post> Get(int id)
        {
            var posts = await db.Posts.Where(a => a.Id == id).ToListAsync();
            Post? post = posts?.FirstOrDefault();
            return post!;
        }
        public async Task<Post> GetByName(string name)
        {
            var posts = await db.Posts.Where(a => a.Name == name).ToListAsync();
            Post? post = posts?.FirstOrDefault();
            return post!;
        }
        public async Task Create(Post post)
        {
            await db.Posts.AddAsync(post);
        }
        public void Update(Post client)
        {
            db.Entry(client).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Post? post = await db.Posts.FindAsync(id);
            if (post != null)
                db.Posts.Remove(post);
        }

    }
}
