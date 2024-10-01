using Microsoft.EntityFrameworkCore;

namespace WebApp.Models {
    public static class SeedData {

        public static void SeedDatabase(DataContext context) {
            context.Database.Migrate();
            if (!context.Products.Any()) {

                
                context.SaveChanges();
            }
        }
    }
}
