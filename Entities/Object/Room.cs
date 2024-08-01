namespace REAgency.DAL.Entities.Object
{
    public class Room : EstateObject //this is would be a table in DB
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Floors { get; set; }

        public double livingArea { get; set; }
    }
}
