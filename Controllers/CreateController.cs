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
            return View();
        }
    }
}