namespace REAgency.DAL.Entities.Locations
{
    public class Locality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual District District { get; set; }
        public int DistrictId { get; set; }
    }
}
