using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using REAgency.DAL.Entities;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Entities.Person;

namespace REAgency.DAL.EF
{
    public class REAgencyContext : DbContext
    {
        //person
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Post> Posts { get; set; }
        //real estate objects

        public DbSet<EstateObject> EstateObjects { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Premis> Premises { get; set; }
        public DbSet<Stead> Steads { get; set; }
        public DbSet<Storage> Storages {  get; set; }
        //location
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        //public DbSet<EstateType> EstateTypes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Article> Articles { get; set; }
        public REAgencyContext(DbContextOptions<REAgencyContext> options)
                   : base(options)
        {
            //if (Database.EnsureCreated())
            //{
            //    Post post1 = new Post();
            //    post1.Name = "administrator";
            //    Posts?.Add(post1);
            //    Post post2 = new Post();
            //    post2.Name = "manager";
            //    Posts?.Add(post2);
            //    Post post3 = new Post();
            //    post3.Name = "real estate specialist";
            //    Posts?.Add(post3);
            //    Post post4 = new Post();
            //    post1.Name = "jurist";
            //    Posts?.Add(post4);

            //    Currency currency1 = new Currency();
            //    currency1.Name = "USD";
            //    Currencies?.Add(currency1);
            //    Currency currency2 = new Currency();
            //    currency2.Name = "EUR";
            //    Currencies?.Add(currency2);
            //    Currency currency3 = new Currency();
            //    currency3.Name = "UAH";
            //    Currencies?.Add(currency3);

            //    Operation operation1 = new Operation();
            //    operation1.Name = "buy";
            //    Operations?.Add(operation1);
            //    Operation operation2 = new Operation();
            //    operation2.Name = "sell";
            //    Operations?.Add(operation2);
            //    Operation operation3 = new Operation();
            //    operation3.Name = "to-rent";
            //    Operations?.Add(operation3);
            //    Operation operation4 = new Operation();
            //    operation4.Name = "for-rent";
            //    Operations?.Add(operation4);
            //}
            //SaveChanges();
        }
    }
    public class SampleContextFactory : IDesignTimeDbContextFactory<REAgencyContext>
    {
        public REAgencyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<REAgencyContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new REAgencyContext(optionsBuilder.Options);
        }
    }
}
