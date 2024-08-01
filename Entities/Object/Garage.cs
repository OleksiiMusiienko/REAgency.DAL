namespace REAgency.DAL.Entities.Object
{
    public class Garage : EstateObject //this is would be a table in DB
    {
        public int Id { get; set; }
        public int Floors { get; set; }
    }
}
