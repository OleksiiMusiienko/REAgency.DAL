namespace REAgency.DAL.Entities.Object
{
    public class Storage 
    {
        public int Id { get; set; }

        public virtual EstateObject estateObject { get; set; }
        public int? estateObjectId { get; set; }
    }
}
