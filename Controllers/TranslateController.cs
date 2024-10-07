using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers {
    public class TranslateController : Controller {

        public IActionResult Index() {
            return View("Base");
        }

        private DataContext context;

        public TranslateController(DataContext dbContext) {
            context = dbContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> TranslateText(Translation translation) {
            
            //return View("Base", await context.Products
            //    .OrderBy(t => t.TranslationId)
            //    .FirstOrDefaultAsync(t => id == null || t.TranslationId == id));

            return View("Base");
        }

        [HttpPost]
        public IActionResult SubmitForm(Translation translation) {
            if (ModelState.IsValid) {

                TempData["translationId"] = translation.TranslationId;
                TempData["english"] = translation.English.ToString();
                TempData["faroese"] = translation.Faroese.ToString();

                return RedirectToAction(nameof(Index));
                
            } else {
                return View("Base");
            }
        }

        [HttpPost]
        public IActionResult ApproveTranslation() {
            
            

            return View("Base");
        }

        
        public IActionResult RedirectToHome() {
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}