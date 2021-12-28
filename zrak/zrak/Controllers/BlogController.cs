using Microsoft.AspNetCore.Mvc;
using System;
using zrak.Models;
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

        [HttpPost]
        public IActionResult AddPost([FromForm] BlogModel blogModel)
        {
            _blogService.AddBlogPost(blogModel);
            return View("BlogView", _blogService.GetBlog());
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpGet()]
        public IActionResult ViewPost(string id) 
        {
            return View(_blogService.ReadBlogPost(id));
        }
    }
}
