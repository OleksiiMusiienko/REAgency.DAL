using REAgency.DAL.Entities.Person;


namespace REAgency.DAL.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAll();
        Task Create(Employee employee); // Это означат что администратор САМ добавляет сотрудников

        void Update(Employee employee);

        Task Delete(int id);

        Task<Employee> Get(int id); // получение сотрудника по id

        Task<Employee> GetByName(string name); // получение сотрудника по имени

        Task<Employee> GetByEmail(string email);

    }
}
