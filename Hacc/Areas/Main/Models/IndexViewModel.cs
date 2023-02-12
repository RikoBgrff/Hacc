using EntityLayer.Entities;
using EntityLayer.Entities.Blog;

namespace Hacc.Areas.Main.Models
{
    public class IndexViewModel
    {
        public List<Post>? Posts { get; set; } = new List<Post>();
        public List<Trip>? Trips { get; set; } = new List<Trip>();
    }
}
