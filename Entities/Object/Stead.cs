using REAgencyEnum;
namespace REAgency.DAL.Entities.Object
{
    public class Stead  //this is would be a table in DB
    {
        public int Id { get; set; }

        public virtual EstateObject estateObject { get; set; }
        public int? estateObjectId { get; set; }

        public string Cadastr { get; set; }
        public LandUse Use { get; set; }
    }
    
}
