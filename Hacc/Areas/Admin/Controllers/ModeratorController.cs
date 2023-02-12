using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Admin.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
