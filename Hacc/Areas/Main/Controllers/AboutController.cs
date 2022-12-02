using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
