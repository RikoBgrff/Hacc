using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Hacc.Areas.Main.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            EFTripRepository efRepo = new EFTripRepository();
            ITripService tripService = new TripManager(efRepo);

            var tripList = tripService.GetList().Select(i => new Trip
            {
                Id = i.Id,
                ImageText = i.ImageText,
                Description = i.Description,
                EstimatedTripDate = i.EstimatedTripDate,
                Status = i.Status,
                FullDescription = i.FullDescription,
                HasImg = i.HasImg,
                RegistrationDeadline = i.RegistrationDeadline,
                Name = i.Name,
                TripType = i.TripType,
            }).ToList();

            IndexViewModel model = new IndexViewModel()
            {
                Trips = tripList,
            };

            return View(model);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
