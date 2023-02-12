using EntityLayer.Entities.Blog;

namespace Hacc.Areas.Blog.Models
{
    public class BlogViewModel
    {
        public List<Post>? Posts { get; set; }
        public List<Tag>? Tags { get; set; }

    }
}
