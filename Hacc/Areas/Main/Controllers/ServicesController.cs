using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]

    public class ServicesController : Controller
    {
        public IActionResult Services()
        {
            return View();
        }
    }
}
