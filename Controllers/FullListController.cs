using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers {
    public class FullListController : Controller {

        private DataContext context;


        public FullListController(DataContext dbContext) {
            context = dbContext;
        }

        public IActionResult Index(int page = 1) {
            return List(page);
        }

        public IActionResult List(int page = 1) {

            if (page <= 0) {
                page = 1;
            }

            TempData["page"] = page;

            int max = page * 1000;
            int min = max - 999;

            return View("List", context.Translations.Where(t => t.TranslationId >= min && t.TranslationId <= max));
        }
    }
}