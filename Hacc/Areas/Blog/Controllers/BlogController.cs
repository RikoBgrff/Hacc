using BussinessLayer.Abstract.BlogAbstract;
using BussinessLayer.Concrete.BlogConcrete;
using DataAccessLayer.EntityFramework.BlogEntityFramework;
using Hacc.Areas.Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hacc.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class BlogController : Controller
    {
        readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Blog()
        {
            EFPostRepository postRepo = new EFPostRepository();
            IPostService postService = new PostManager(postRepo);

            EFTagRepository tagRepo = new EFTagRepository();
            ITagService tagService = new TagManager(tagRepo);

            var postList = postService.GetList();
            var tagList = tagService.GetAll();

            var model = new BlogViewModel
            {
                Posts = postList,
                Tags = tagList,
            };
            return View(model);
        }
    }
}