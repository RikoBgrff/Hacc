using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Admin.Models
{
    public class UserRoleViewModel
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? RoleName { get; set; }
        public IList<string>? RoleNames { get; set; }
    }
}
