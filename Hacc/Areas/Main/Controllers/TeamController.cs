using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]
    public class TeamController : Controller
    {
        public IActionResult Team()
        {
            return View();
        }
    }
}
