using REAgency.DAL.Entities.Person;

namespace REAgency.DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Employee Employee { get; set; }
        public int employeeId { get; set; }
        public DateTime ArticleDate { get; set; }
        public string? pathImage { get; set; }
    }
}
