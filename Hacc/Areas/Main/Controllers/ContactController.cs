using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }
        public IActionResult Contact()
        {
            EFContactRepository contactRepo = new EFContactRepository();
            IContactService contactService = new ContactManager(contactRepo);

            var contactData = contactService.GetList();
            Contact model = new Contact();
            foreach (var item in contactData)
            {
                model = item;
            }
            return View(model);
        }
    }
}
