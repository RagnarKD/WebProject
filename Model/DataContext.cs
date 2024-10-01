using Microsoft.EntityFrameworkCore;

namespace WebProject.Model {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Translation> Translations => Set<Translation>();
    }
}
