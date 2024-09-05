using System.ComponentModel.DataAnnotations.Schema;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Entities.Person;

namespace REAgency.DAL.Entities.Object
{
    public class EstateObject 
    {
        public int Id { get; set; }
        public int countViews { get; set; }
        public virtual Client Client {  get; set; }
      
        public int clientId { get; set; }

        public virtual Employee Employee { get; set; }
        public int employeeId { get; set; }

        public virtual Operation Operation { get; set; }
        public int operationId { get; set; }

        public virtual Location Location { get; set; }
        public int locationId { get; set; }

        public string Street {  get; set; }
        public int numberStreet { get; set; }
        public int Price { get; set; }
        public virtual Currency Currency { get; set; }
        public int currencyId { get; set; }
        public double Area { get; set; }

        public virtual Area unitArea { get; set; }
        public int unitAreaId { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public string pathPhoto {  get; set; }

        //public virtual ICollection<Flat> Flats { get; set; }
        public virtual ICollection<Garage> Garages { get; set; }
        public virtual ICollection<House> Houses { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual ICollection<Premis> Premises { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Stead> Steads { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
        
    }
}
