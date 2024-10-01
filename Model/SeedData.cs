using Microsoft.EntityFrameworkCore;
using WebProject.Services;

namespace WebProject.Model {
    public static class SeedData {
        

        public static void SeedDatabase(DataContext context, ICSVService csvService, Stream file) {
            context.Database.Migrate();
            if (!context.Translations.Any()) {

                context.Translations.AddRange(csvService.ReadCSV<Translation>(file));
                // foreach (Translation translation in translations) {
                //     Console.Write(translation.English + ", " + translation.Faroese + "\n");
                // }
                context.SaveChanges();
            }
        }
    }
}
