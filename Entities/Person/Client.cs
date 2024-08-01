namespace REAgency.DAL.Entities.Person
{
    public class Client : Person
    {
        public int Id { get; set; }
        
        public virtual Operation Operation { get; set; }
        public int operationId { get; set; }

        public virtual Employee Employee { get; set; }
        public int employeeId { get; set; }

        public bool status { get; set; }

        public string? Password { get; set; }
        public string? Salt { get; set; }

    }
}
