using EntityLayer.Entities;

namespace Hacc.Areas.Admin.Models
{
    public class AssignRoleToUserViewModel
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
    }
}
