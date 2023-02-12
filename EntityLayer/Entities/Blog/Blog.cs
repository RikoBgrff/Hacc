using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Blog
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Post>? Posts { get; set; } = new List<Post>();
        public DateTime CreateTime { get; set; }
        public int Status { get; set; }
    }
}
