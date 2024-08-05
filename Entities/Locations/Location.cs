namespace REAgency.DAL.Entities.Locations
{
    public class Location
    {
        public int Id { get; set; }
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }
        public virtual Region Region { get; set; }
        public int? RegionId { get; set; }
        public virtual District District { get; set; }
        public int?  DistrictId { get; set; }
        public virtual Locality Locality { get; set; }
        public int? LocalityId { get; set; }
        
    }
}
