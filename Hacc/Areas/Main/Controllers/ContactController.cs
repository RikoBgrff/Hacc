using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
