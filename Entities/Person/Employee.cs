using REAgency.DAL.Entities.Object;

namespace REAgency.DAL.Entities.Person
{
    public class Employee : Person
    {
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[]? Avatar { get; set; }
        public string? Phone2 { get; set; }
        public DateTime dateReg { get; set; }

        public bool adminStatus { get; set; }
        public virtual Post Post { get; set; }
        public int postId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EstateObject> EstateObjects { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

    }
}
