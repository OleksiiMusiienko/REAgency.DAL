using REAgency.DAL.Entities.Person;

namespace REAgency.DAL.Interfaces
{
    public interface IPost
    {
        Task<IEnumerable<Post>> GetAll();
        Task Create(Post post); 

        void Update(Post post);

        Task Delete(int id);

        Task<Post> Get(int id); 

        Task<Post> GetByName(string name); 
    }
}
