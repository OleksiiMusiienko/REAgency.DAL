namespace REAgency.DAL.Entities.Object
{
    public class Garage //this is would be a table in DB
    {
        public int Id { get; set; }

        public virtual EstateObject estateObject { get; set; }
        public int estateObjectId { get; set; }

        public int Floors { get; set; }
    }
}
