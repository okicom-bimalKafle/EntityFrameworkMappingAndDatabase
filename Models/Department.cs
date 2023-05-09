namespace EntityFrameworkMappingAndDatabase.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }=new List<Employee>();

    }
}
