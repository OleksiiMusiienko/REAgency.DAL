using REAgency.DAL.Entities.Person;

namespace REAgency.DAL.Interfaces
{
    public interface IClient
    {
        Task<IEnumerable<Client>> GetAll();
        Task Create(Client client); // Регистрация пользователя или добавление пользователя сотрудником

        void Update(Client client);

        Task Delete(int id);

        Task<Client> Get(int id); // получение пользователя по id

        Task<Client> GetByName(string name); // получение пользователя по имени
    }
}
