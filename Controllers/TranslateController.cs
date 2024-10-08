using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers {
    public class TranslateController : Controller {

        public IActionResult Index() {
            return View("Translate");
        }

        private DataContext context;

        public TranslateController(DataContext dbContext) {
            context = dbContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> TranslateText(TranslateViewModel viewModel) {
            
            if (!await context.Translations.AnyAsync(c => c.English == viewModel.English || c.Faroese == viewModel.Faroese)) {
                ModelState.AddModelError(nameof(viewModel.English), "Eingin týðing funnin.");
            }
            
            if (ModelState.IsValid) {
                Console.WriteLine("Translation found");

                await CompleteTranslation(viewModel);
                ModelState.Clear();

                return View("Translate", viewModel);

            } else {
                Console.WriteLine("None found");
                Console.WriteLine(viewModel.English);
                return View("Translate");
            }

        }

        private async Task CompleteTranslation(TranslateViewModel viewModel) {
            var translation = await context.Translations
                    .OrderBy(t => t.Approval)
                    .FirstOrDefaultAsync(t => t.English == viewModel.English || t.Faroese == viewModel.Faroese);

            viewModel.English = translation!.English;
            Console.WriteLine(viewModel.English);
            viewModel.Faroese = translation!.Faroese;
            Console.WriteLine(viewModel.Faroese);
        }

        [HttpPost]
        public IActionResult ApproveTranslation() {
            
            

            return View("Translate");
        }
    }
}