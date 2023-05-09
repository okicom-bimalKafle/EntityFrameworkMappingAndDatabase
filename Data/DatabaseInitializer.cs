namespace EntityFrameworkMappingAndDatabase.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MyDbContext>();

                context.Database.EnsureCreated();
            }
        }
    }
}
