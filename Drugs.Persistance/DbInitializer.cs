namespace Drugs.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(DrugsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
