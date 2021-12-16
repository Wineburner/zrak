using Microsoft.AspNetCore.Mvc;
using zrak.Services;

namespace zrak.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService) 
        {
            _blogService = blogService;
        }

        public IActionResult BlogView()
        {
            return View(_blogService.GetBlog());
        }
    }
}
