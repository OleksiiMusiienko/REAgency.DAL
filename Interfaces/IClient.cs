using REAgency.DAL.Entities.Person;

namespace REAgency.DAL.Interfaces
{
    public interface IClient
    {
        Task<IEnumerable<Client>> GetAll();

        Task<IEnumerable<Client>> GetAllByEmployee(int id);  //я(Лев) добавил в интерфейс два метода которые реализовывает класс, но они не были в интерфейсе
        Task<IEnumerable<Client>> GetAllByOperation(int opId);
        Task Create(Client client); // Регистрация пользователя или добавление пользователя сотрудником

        void Update(Client client);

        Task Delete(int id);

        Task<Client> Get(int id); // получение пользователя по id

        Task<Client> GetByName(string name); // получение пользователя по имени

        Task<Client> GetByEmail(string email);
    }
}
