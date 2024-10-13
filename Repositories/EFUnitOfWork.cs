using REAgency.DAL.EF;
using REAgency.DAL.Entities;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using REAgency.DAL.Repositories.OtherRepository;
using REAgency.DAL.Repositories.LocationsRepository;
using REAgency.DAL.Repositories.ObjectRepository;
using REAgency.DAL.Repositories.PersonRepository;

namespace REAgency.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private REAgencyContext db;

        private ClientRepository clientRepository;
        private EmployeeRepository employeeRepository;

        private CountryRepository countryRepository;
        private DistrictRepository districtRepository;
        private LocalityRepository localityRepository;
        private LocationRepository locationRepository;
        private RegionRepository regionRepository;

        private FlatRepository flatRepository;
        private GarageRepository garageRepository;
        private HouseRepository houseRepository;
        private OfficeRepository officeRepository;
        private ParkingRepository parkingRepository;
        private PremisRepository premiseRepository;
        private RoomRepository roomRepository;
        private SteadRepository steadRepository;
        private StorageRepository storageRepository;

        private ArticleRepository articleRepository;
        private AreaRepository areaRepository;
        private CurrencyRepository currencyRepository;
        private OrderRepository orderRepository;
        private OperationRepository operationRepository;
        private PostRepository postRepository;
        private EstateObjectRepository estateObjectRepository;

        public EFUnitOfWork(REAgencyContext context)
        {
            db = context;
        }

        //person
        public IClient Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }
        public IEmployee Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        //location
        public ILocation<Country> Countries
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepository(db);
                return countryRepository;
            }
        }
        public ILocation<District> Districts
        {
            get
            {
                if(districtRepository == null)
                    districtRepository = new DistrictRepository(db);
                return districtRepository;
            }
        }
        public ILocation<Locality> Localities
        {
            get
            {
                if(localityRepository == null)
                   localityRepository = new LocalityRepository(db);
                return localityRepository;
            }
        }
        public ILocation<Location> Locations
        {
            get
            {
                if(locationRepository == null)
                    locationRepository = new LocationRepository(db);
                return locationRepository;
            }
        }
        public ILocation<Region> Regions
        {
            get
            {
                if(regionRepository == null)
                    regionRepository = new RegionRepository(db);
                return regionRepository;
            }
        }

        //Real estate objects
        public IRepositoryObject<Flat> Flats
        {
            get
            {
                if(flatRepository == null)
                    flatRepository = new FlatRepository(db);
                return flatRepository;
            }

        }       
        public IRepositoryObject<Garage> Garages
        {
            get
            {
                if(garageRepository == null)
                    garageRepository = new GarageRepository(db);
                return garageRepository;
            }
        }
        public IRepositoryObject<House> Houses
        {
            get
            {
                if(houseRepository == null)
                    houseRepository = new HouseRepository(db);
                return houseRepository;
            }
        }
        public IRepositoryObject<Office> Offices
        {
            get
            {
                if(officeRepository == null)
                    officeRepository = new OfficeRepository(db);
                return officeRepository;
            }
        }
        public IRepositoryObject<Parking> Parkings
        {
            get
            {
                if(parkingRepository == null)
                    parkingRepository = new ParkingRepository(db);
                return parkingRepository;
            }
          
        }
        public IRepositoryObject<Premis> Premises
        {
            get
            {
                if(premiseRepository == null)
                    premiseRepository = new PremisRepository(db);
                return premiseRepository;
            }
        }
        public IRepositoryObject<Room> Rooms
        {
            get
            {
                if(roomRepository == null)
                    roomRepository = new RoomRepository(db);
                return roomRepository;
            }
        }
        public IRepositoryObject<Stead> Steads
        {
            get
            {
                if(steadRepository == null)
                    steadRepository = new SteadRepository(db);
                return steadRepository;
            }
        }
        public IRepositoryObject<Storage> Storeges
        {
            get
            {
                if(storageRepository == null)
                    storageRepository = new StorageRepository(db);
                return storageRepository;
            }
        }

        //other
        public IArticle Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }
        public IElseEntities<Area> Areas
        {
            get
            {
                if(areaRepository == null)
                    areaRepository = new AreaRepository(db);
                return areaRepository;
            }
        }
        public IElseEntities<Currency> Currencies
        {
            get
            {
                if(currencyRepository == null) 
                    currencyRepository = new CurrencyRepository(db); 
                return currencyRepository;
            }
        }
        public IOrdered Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IElseEntities<Operation> Operations
        {
            get
            {
                if(operationRepository == null)
                    operationRepository = new OperationRepository(db);
                return operationRepository;
            }
        }
        public IPost Posts
        {
            get
            {
                if(postRepository == null)
                    postRepository = new PostRepository(db);
                return postRepository;
            }
        }
        public IEstateObject EstateObjects
        {
            get
            {
                if (estateObjectRepository == null)
                    estateObjectRepository = new EstateObjectRepository(db);
                return estateObjectRepository;
            }
        }

        public async Task Save()
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               
            }
            
        }

    }
}
