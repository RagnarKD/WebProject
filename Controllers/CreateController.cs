using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers {
    public class CreateController : Controller {

        private DataContext context;


        public CreateController(DataContext dbContext) {
            context = dbContext;
        }

        public IActionResult Index() {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TranslateViewModel viewModel) {
            if (string.IsNullOrEmpty(viewModel.English)) {
                ModelState.AddModelError(nameof(viewModel.English), "Skriva í \"Enskt\" teigin.");
            }

            if (string.IsNullOrEmpty(viewModel.Faroese)) {
                ModelState.AddModelError(nameof(viewModel.Faroese), "Skriva í \"Føroyskt\" teigin.");
            }

            if (await context.Translations.AnyAsync(t => t.English == viewModel.English && t.Faroese == viewModel.Faroese)) {
                ModelState.AddModelError(nameof(viewModel), "Týðingin er longu skrásett.");
            }

            if (!ModelState.IsValid) {
                return View(viewModel);
            }

            ModelState.Clear();
            var translation = new Translation {
                English = viewModel.English,
                Faroese = viewModel.Faroese,
                Approval = 0
            };

            await context.Translations.AddAsync(translation);
            await context.SaveChangesAsync();
            
            var newestTranslation = await context.Translations.FirstOrDefaultAsync(t => t.English == translation.English
                    && t.Faroese == translation.Faroese);
            
            return View("Result", newestTranslation);
        }
    }
}