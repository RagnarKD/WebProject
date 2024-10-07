using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers {
    public class HomeController : Controller {

        private DataContext context;


        public HomeController(DataContext dbContext) {
            context = dbContext;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult RedirectToTranslate() {
            return RedirectToActionPermanent("Index", "Translate");
        }

        public IActionResult RedirectToFullList() {
            return RedirectToActionPermanent("Index", "FullList");
        }

        public IActionResult RedirectToCreate() {
            return RedirectToActionPermanent(nameof(TranslateController.Index), nameof(TranslateController));
        }
    }
}