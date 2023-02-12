using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Hacc.Areas.Main.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Main.Controllers
{
    [Area("Main")]
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }


        public IActionResult About()
        {
            EFTeamRepository teamRepo = new EFTeamRepository();
            ITeamService teamService = new TeamManager(teamRepo);

            var model = teamService.GetList().Select(i => new Team
            {
                Name = i.Name,
                Status = i.Status,
                Description = i.Description,
                HasImg = i.HasImg,
                Id = i.Id,
                ImageText = i.ImageText,
                MemberFullName = i.MemberFullName,
                MemberPosition = i.MemberPosition,
            }).ToList();
            return View(model);
        }
    }
}
