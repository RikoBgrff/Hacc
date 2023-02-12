using BussinessLayer.Abstract;
using BussinessLayer.Abstract.BlogAbstract;
using BussinessLayer.Concrete;
using BussinessLayer.Concrete.BlogConcrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.EntityFramework.BlogEntityFramework;
using EntityLayer.Entities;
using EntityLayer.Entities.Blog;
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

            EFPostRepository eFPost = new EFPostRepository();
            IPostService postService = new PostManager(eFPost);

            var baselineDate = DateTime.Now.AddDays(-70);

            var postList = postService.GetList().Select(i => new Post
            {
                Body = i.Body,
                Title = i.Title,
                CreateDate = i.CreateDate,
                Id = i.Id,
            }).Where(i => i.CreateDate > baselineDate).OrderByDescending(i => i.CreateDate).Take(4).ToList();

            IndexViewModel model = new IndexViewModel()
            {
                Posts = postList,
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
