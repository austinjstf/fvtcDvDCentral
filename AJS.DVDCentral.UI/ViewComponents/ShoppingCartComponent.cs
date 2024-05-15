using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.UI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AJS.DVDCentral.UI.ViewComponents
{
    public class ShoppingCartComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return View(HttpContext.Session.GetObject<ShoppingCart>("cart"));
            }
            else
            {
                return View (new ShoppingCart());
            }
        }
    }
}
