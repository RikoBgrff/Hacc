using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Admin.Models
{
    public class UsersInRoleViewModel
    {
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public IList<AppUser>? Users { get; set; } = new List<AppUser>();
    }
    }
