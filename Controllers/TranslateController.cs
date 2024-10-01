using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers {
    public class TranslateController : Controller {
        public IActionResult Index() {
            return View("Base");
        }

        private DataContext context;

        public TranslateController(DataContext dbContext) {
            context = dbContext;
        }

        [HttpPost]
        public IActionResult TranslateText(Translation translation) {
            if (ModelState.IsValid) {

                TempData["translationId"] = translation.TranslationId;
                TempData["english"] = translation.English.ToString();
                TempData["faroese"] = translation.Faroese.ToString();

                return RedirectToAction(nameof(Results));
                
            } else {
                return View("Base");
            }
        }

        [HttpPost]
        public IActionResult SubmitForm(Translation translation) {
            if (ModelState.IsValid) {

                TempData["translationId"] = translation.TranslationId;
                TempData["english"] = translation.English.ToString();
                TempData["faroese"] = translation.Faroese.ToString();

                return RedirectToAction(nameof(Results));
                
            } else {
                return View("Base");
            }
        }

        public IActionResult Results() {
            return View(TempData);
        }
    }
}