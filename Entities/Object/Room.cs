namespace REAgency.DAL.Entities.Object
{
    public class Room  //this is would be a table in DB
    {
        public int Id { get; set; }

        public virtual EstateObject estateObject { get; set; }
        public int? estateObjectId { get; set; }

        public int Floor { get; set; }
        public int Floors { get; set; }

        public double livingArea { get; set; }
    }
}
