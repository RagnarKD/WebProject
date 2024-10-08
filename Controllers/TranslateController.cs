using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebProject.Model;

namespace WebProject.Controllers {
    public class TranslateController : Controller {

        //private TranslateViewModel PreviousViewModel;
        //private IQueryable<Translation> PreviousLeftOverTranslations;

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

                //PreviousViewModel = viewModel;

                return View("Translate", viewModel);

            } else {
                Console.WriteLine("None found");
                Console.WriteLine(viewModel.English);
                return View("Translate");
            }

        }

        private async Task CompleteTranslation(TranslateViewModel viewModel) {
            var translations = context.Translations
                    .OrderBy(t => t.Approval)
                    .Where(t => t.English == viewModel.English || t.Faroese == viewModel.Faroese);
            
            ViewBag.LeftOverTranslations = translations;
            //PreviousLeftOverTranslations = translations;
            
            var translation = translations.FirstOrDefault();

            viewModel.English = translation!.English;
            Console.WriteLine(viewModel.English);
            viewModel.Faroese = translation!.Faroese;
            Console.WriteLine(viewModel.Faroese);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveTranslation(long Id) {

            Translation translation = context.Translations.FirstOrDefault(t => t.TranslationId == Id);

            if (translation != null) {

                translation.Approval++;

                context.Translations.Update(translation);
                await context.SaveChangesAsync();
            }

            //ViewBag.LeftOverTranslations = PreviousLeftOverTranslations;
            
            return View("Translate");
        }
    }
}