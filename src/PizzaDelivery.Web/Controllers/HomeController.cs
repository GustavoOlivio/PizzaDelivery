using Microsoft.AspNetCore.Mvc;

namespace PizzaDelivery.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
