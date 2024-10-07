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
    }
}