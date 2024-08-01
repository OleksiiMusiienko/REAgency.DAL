namespace REAgency.DAL.Entities.Object
{
    public class House : EstateObject //this is would be a table in DB
    {
        public int Id { get; set; }
        public int Floors { get; set; }
        public int Rooms { get; set; }
        public double steadArea { get; set; }

        public double kitchenArea { get; set; }
        public double livingArea { get; set; }

    }
}
