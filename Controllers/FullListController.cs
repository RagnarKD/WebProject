using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers {
    public class FullListController : Controller {

        private DataContext context;


        public FullListController(DataContext dbContext) {
            context = dbContext;
        }

        public IActionResult Index() {
            return View("List", context.Translations);
        }
    }
}