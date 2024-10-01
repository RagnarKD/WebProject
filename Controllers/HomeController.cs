using Microsoft.AspNetCore.Mvc;
namespace WebProject.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}