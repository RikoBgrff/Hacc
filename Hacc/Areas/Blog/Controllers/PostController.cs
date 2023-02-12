using BussinessLayer.Abstract.BlogAbstract;
using BussinessLayer.Concrete.BlogConcrete;
using DataAccessLayer.EntityFramework.BlogEntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class PostController : Controller
    {
        readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        public IActionResult Post(int id)
        {
            EFPostRepository postRepo = new EFPostRepository();
            IPostService postService = new PostManager(postRepo);
            var model = postService.GetList().FirstOrDefault(p => p.Id == id);
            return View(model);
        }
    }
}
