namespace EntityFrameworkMappingAndDatabase.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public virtual Passport? Passport { get; set; }

    }
}
