using REAgency.DAL.Entities.Person;

namespace REAgency.DAL.Entities.Object
{
    public class Flat  // Это будет таблица в БД
    {
        public int Id { get; set; }

        public virtual EstateObject estateObject { get; set; }

        public int? estateObjectId { get; set; }

        public int Floor { get; set; }
        public int Floors { get; set; }

        public int Rooms { get; set; }

        public double kitchenArea { get; set; }
        public double livingArea { get; set; }

    }
}
