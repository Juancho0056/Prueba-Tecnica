using System.Threading.Tasks;

namespace Ophelia.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
    
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
                await context.SaveChangesAsync();
        }
    }
}
