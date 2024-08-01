namespace REAgency.DAL.Entities.Locations
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
