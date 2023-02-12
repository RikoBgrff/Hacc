using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]
    public class TripController : Controller
    {

        private readonly ILogger<TripController> _logger;

        public TripController(ILogger<TripController> logger)
        {
            _logger = logger;
        }

        public IActionResult Trips()
        {
            EFTripRepository efRepo = new EFTripRepository();
            ITripService tripService = new TripManager(efRepo);

            var tripList = tripService.GetList();
            var model = tripList.Select(i => new Trip
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

            return View(model);
        }
        public IActionResult Trip(int id)
        {
            EFTripRepository efRepo = new EFTripRepository();
            ITripService tripService = new TripManager(efRepo);
            var trip = tripService.GetById(id);
            return View(trip);
        }
    }
}
