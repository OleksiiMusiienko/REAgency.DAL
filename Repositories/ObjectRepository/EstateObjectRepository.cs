using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using REAgencyEnum;

namespace REAgency.DAL.Repositories.ObjectRepository
{
    public class EstateObjectRepository : IEstateObject
    { 
        private REAgencyContext db;

        public EstateObjectRepository(REAgencyContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<EstateObject>> GetAll()
        {
            return await db.EstateObjects.Include(c => c.Client).OrderByDescending(o => o.Date).ToListAsync();
        }
        public async Task<EstateObject> Get(int id)
        {
            EstateObject? obj = await db.EstateObjects.FindAsync(id);
            return obj!;
        }
        public async Task<IEnumerable<EstateObject>> GetAllByEmployeeId(int id)
        {
            var estateObjects = await db.EstateObjects.Where(f => f.employeeId == id).OrderByDescending(o => o.Date).ToListAsync();
            return estateObjects;
        }

        public async Task<IEnumerable<EstateObject>> GetAllByOperationId(int id)
        {
            var estateObjects = await db.EstateObjects.Where(f => f.operationId == id).OrderByDescending(o => o.Date).ToListAsync();
            return estateObjects;
        }

        public async Task<IEnumerable<EstateObject>> GetAllByLocalityId(int id)
        {
            var estateObjects = (from o in db.EstateObjects
                          join l in db.Locations on o.locationId equals l.Id
                          where l.LocalityId == id
                          select o).ToList();

            return estateObjects;
        }

        public async Task<IEnumerable<EstateObject>> GetAllByEstateTypeId(int id)
        {
            var estateObjects = await db.EstateObjects
                                 .Where(o => (int)o.estateType == id)
                                 .ToListAsync();
            return estateObjects;
        }
        public async Task<IEnumerable<EstateObject>> GetAllByOperationAndLocalityId(int opId, int localityId)
        {
            var estateObjects = (from eo in db.EstateObjects
                                 join o in db.Operations on eo.operationId equals o.Id
                                 join l in db.Locations on eo.locationId equals l.Id
                                 where l.LocalityId == localityId
                                 where o.Id == opId
                                 select eo).ToList();

            return estateObjects;
        }
        public async Task<IEnumerable<EstateObject>> GetAllByFiltered(int? typeId, int? operationTypeId, int? localityId, int? minPrice,
            int? maxPrice, double? minArea, double? maxArea)
        {
            var estateObjects = db.EstateObjects.AsQueryable();  

            
            if (typeId != 0)
            {
                estateObjects = estateObjects.Where(eo => eo.estateType == (ObjectType)typeId.Value);
            }

            if (operationTypeId != 0)
            {
                estateObjects = estateObjects.Where(eo => eo.operationId == operationTypeId.Value);
            }
            
            if (localityId != 0)
            {
                estateObjects = (from o in db.EstateObjects
                         join l in db.Locations on o.locationId equals l.Id
                         where l.LocalityId == localityId
                         select o);
            }

            if (minPrice != 0)
            {
                estateObjects = estateObjects.Where(eo => eo.Price >= minPrice.Value);
            }

            if (maxPrice != 0)
            {
                estateObjects = estateObjects.Where(eo => eo.Price <= maxPrice.Value);
            }

            
            if (minArea != 0)
            {
                estateObjects = estateObjects.Where(eo => eo.Area >= minArea.Value);
            }

            if (maxArea != 0)
            {
                estateObjects = estateObjects.Where(eo => eo.Area <= maxArea.Value);
            }

            return await estateObjects.OrderByDescending(o => o.Date).ToListAsync();
        }

        public async Task Create(EstateObject obj)
        {
            await db.EstateObjects.AddAsync(obj);
        }

        public async Task<EstateObject> GetByDateTime(DateTime date)
        {
            var estateObjects = await db.EstateObjects.Where(f => f.Date == date).ToListAsync();
            EstateObject? estateObject = estateObjects.FirstOrDefault();
            return estateObject!;
        }
        public async void Update(EstateObject obj)
        {
            
             db.Entry(obj).State = EntityState.Modified;
            

        }
        public async Task Delete(int id)
        {
            EstateObject? obj = await db.EstateObjects.FindAsync(id);
            if (obj != null)
                db.EstateObjects.Remove(obj);
        }
    }
}
