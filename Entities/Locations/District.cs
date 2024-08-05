namespace REAgency.DAL.Entities.Locations
{
    public class District
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public virtual Region Region { get; set; }
        public int? RegionId { get; set;}

        public virtual ICollection<Locality> Localities { get; set; }
    }
}
