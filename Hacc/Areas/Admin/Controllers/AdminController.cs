using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Hacc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
#nullable disable
namespace Hacc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(ILogger<AdminController> logger, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult UsersList(List<UserRoleViewModel> model)
        {
            var list = _userManager.Users;
            foreach (var user in list)
            {
                model.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                });
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "SuperAdmin,0Admin,Moderator")]
        public IActionResult UserEdit(string id)
        {
            if (id != null)
            {

                var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
                if (user == null) return View("Error");
                else
                {
                    UserRoleViewModel model = new UserRoleViewModel()
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                    };
                    return View(model);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult UserEditAsync(UserRoleViewModel model)
        {
            if (model == null) return View("Error");
            if (model != null)
            {

                EFAppUserRepository eFAppUserRepository = new EFAppUserRepository();
                IAppUserService appUserService = new AppUserManager(eFAppUserRepository);

                var u = (from i in appUserService.GetList() where i.Id == model.UserId select i).FirstOrDefault();
                u.UserName = model.UserName;
                u.PhoneNumber = model.PhoneNumber;
                u.NormalizedUserName = model.UserName.ToUpper();
                appUserService.AppUserUpdate(u);
                //ViewBag.Info = "User Info Updated Successfully";
                //ViewBag.Status = "Ok";
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserDelete(string id)
        {
            if (id != null)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
                if (user == null) return View("Error");
                else
                {
                    UserRoleViewModel model = new UserRoleViewModel()
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                    };
                    return View(model);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult UserDelete(UserRoleViewModel model)
        {
            //if (ModelState.IsValid)
            //{

            //}
            if (model != null)
            {
                EFAppUserRepository eFAppUserRepository = new EFAppUserRepository();
                IAppUserService appUserService = new AppUserManager(eFAppUserRepository);
                var u = (from i in appUserService.GetList() where i.Id == model.UserId select i).FirstOrDefault();
                appUserService.AppUserRemove(u);
                return RedirectToAction("UsersList", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return View("Error");
            else
            {
                List<string> roleNames = new List<string>();
                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    roleNames.Add(role);
                }
                UserRoleViewModel model = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    RoleNames = roleNames,
                };
                return View(model);
            }
        }


        public async Task<IActionResult> RoleCreate(UserRoleViewModel model)
        {
            string roleName = model.RoleName;
            if (roleName == null)
            {
                return View(model);
            }
            else
            {

                var result = await _roleManager.RoleExistsAsync(roleName);
                if (result == false)
                {
                    AppRole appRole = new AppRole()
                    {
                        Name = roleName,
                    };
                    await _roleManager.CreateAsync(appRole);
                }
                return View(model);
            }
        }

        public IActionResult RolesList(List<UserRoleViewModel> model)
        {
            var list = _roleManager.Roles;
            foreach (var role in list)
            {
                model.Add(new UserRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult RoleDelete(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null) return View("Error");
            else
            {
                UserRoleViewModel model = new UserRoleViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult RoleDelete(UserRoleViewModel model)
        {

            {
                //if (ModelState.IsValid)
                //{

                //}
                if (model != null)
                {
                    EFAppRoleRepository efAppRoleRepo = new EFAppRoleRepository();
                    IAppRoleService appRoleService = new AppRoleManager(efAppRoleRepo);
                    var u = (from i in appRoleService.GetList() where i.Id == model.RoleId select i).FirstOrDefault();
                    appRoleService.AppRoleRemove(u);
                    return RedirectToAction("RolesList", "Admin");
                }
                else
                {
                    return View(model);
                }
            }
        }

        public async Task<IActionResult> UsersInRole(string id)
        {
            var roleName = _roleManager.Roles.FirstOrDefault(x => x.Id == id).Name;
            var users = await _userManager.GetUsersInRoleAsync(roleName);
            UsersInRoleViewModel model = new UsersInRoleViewModel();
            model.RoleName = roleName;
            model.Users = users;
            return View(model);
        }

        [HttpGet]
        public IActionResult AssignRoleToUser(string id)
        {
            var user = _userManager.Users.FirstOrDefault(i => i.Id == id);
            AssignRoleToUserViewModel model = new AssignRoleToUserViewModel()
            {
                UserName = user.UserName,
            };
            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (var role in _roleManager.Roles)
            {
                roles.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }
            ViewBag.Roles = roles;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserViewModel model)
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (var role in _roleManager.Roles)
            {
                roles.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }
            ViewBag.Roles = roles;
            if (model.UserName != null && model.RoleName != null)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if ((await _userManager.IsInRoleAsync(user, model.RoleName)) == false)
                {
                    var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (result.Succeeded)
                    {
                        ViewBag.Info = "Role Added";
                    }
                    else
                    {
                        ViewBag.Info = "Role Could not add";
                    }
                }
                else
                {
                    ViewBag.Info = "User is in role already";
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Super Admin,Admin,Moderator")]
        public IActionResult GetCurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                //return RedirectToAction("Action", new { id = 99 });
                var userId = _userManager.GetUserId(HttpContext.User);
                return RedirectToAction("UserDetails", new { id = userId });
            }
            else
            {
                return RedirectToAction("Login", "Account", "Identity");
            }
        }
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUserRole(string id)
        {
            var user = _userManager.Users.FirstOrDefault(i => i.Id == id);
            AssignRoleToUserViewModel model = new AssignRoleToUserViewModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
            };
            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                roles.Add(new SelectListItem() { Value = role, Text = role });
            }
            ViewBag.Roles = roles;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUserRole(AssignRoleToUserViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(i => i.UserName == model.UserName);

            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                roles.Add(new SelectListItem() { Value = role, Text = role });
            }
            ViewBag.Roles = roles;

            if (model.UserName != null && model.RoleName != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                if (result.Succeeded)
                {
                    ViewBag.Info = "Role Removed";
                }
                if (!result.Succeeded)
                {
                    ViewBag.Info = "Role Could Not Removed\n" + result.Errors;
                }

            }
            return View(model);
        }

        public IActionResult AddTrip()
        {
            return View();
        }
        public IActionResult EditTrip(int id)
        {
            EFTripRepository tripRepo = new EFTripRepository();
            ITripService tripService = new TripManager(tripRepo);
            Trip trip = new Trip();
            if (tripService.GetById(id) != null)
            {
                trip = tripService.GetById(id);
            }
            return View(trip);
        }
    }
}
