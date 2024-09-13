using REAgency.DAL.Entities;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Entities.Object;

namespace REAgency.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        //person
        IEmployee Employees { get; }
        IClient Clients { get; }
        IPost Posts { get; }

        //location
        ILocation<Country> Countries { get; }
        ILocation<District> Districts { get; }
        ILocation<Locality> Localities { get; }
        ILocation<Location> Locations { get; }
        ILocation<Region> Regions { get; }

        //real estate objects
        IRepositoryObject<Flat> Flats { get; }
        IRepositoryObject<House> Houses { get; }      
        IRepositoryObject<Garage> Garages { get; }
        IRepositoryObject<Office> Offices { get; }
        IRepositoryObject<Parking> Parkings { get; }
        IRepositoryObject<Premis> Premises { get; }
        IRepositoryObject<Room> Rooms { get; }
        IRepositoryObject<Stead> Steads { get; }
        IRepositoryObject<Storage> Storeges { get; }

        IEstateObject EstateObjects { get; }

        //other methods
        IElseEntities<Area> Areas { get; }
        IElseEntities<Operation> Operations { get; }
        IElseEntities<Currency> Currencies { get; }
        IOrdered Orders { get; }
        IArticle Articles { get; }
        Task Save(); 
    }
}
