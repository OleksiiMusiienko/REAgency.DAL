using REAgency.DAL.Entities;

namespace REAgency.DAL.Interfaces
{
    public interface IArticle
    {        
        Task Create(Article client);
        void Update(Article client);
        Task Delete(int id);
        Task<Article> Get(int id); 
        Task<IEnumerable<Article>> GetAll();
        Task<IEnumerable<Article>> GetAllByEmployee(int id);
    }
}
