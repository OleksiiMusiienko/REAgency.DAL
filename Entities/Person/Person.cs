namespace REAgency.DAL.Entities.Person
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Phone1 { get; set;}
        public string? Email { get; set;} //регистрация по почте
        public bool userStatus { get; set;}
        public DateOnly? DateOfBirth { get; set;}
    }
}
