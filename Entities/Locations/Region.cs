namespace REAgency.DAL.Entities.Locations
{
    public class Region
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
