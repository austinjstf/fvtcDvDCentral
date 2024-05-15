using Microsoft.AspNetCore.Mvc;

namespace AJS.WebApp.UI.Controllers
{
    public class BingoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
