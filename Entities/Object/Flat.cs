namespace REAgency.DAL.Entities.Object
{
    public class Flat : EstateObject // Это будет таблица в БД
    {
        public int Id { get; set; }

        public int Floor { get; set; }
        public int Floors { get; set; }

        public int Rooms { get; set; }

        public double kitchenArea { get; set; }
        public double livingArea { get; set; }

    }
}
