namespace EntityFrameworkMappingAndDatabase.Models
{
    public class Passport
    {
        public int PassportId { get; set; }
        public string Number { get; set; }
        public int PersonId { get; set; }
        public virtual Person? Person { get; set; }

    }
}
