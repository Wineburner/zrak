using zrak.Models;

namespace zrak.Services
{
    public class BlogService : IBlogService
    {
        public BlogModel GetBlog() 
        {
            return new BlogModel()
            {
                Greet = "Blogs"
            };
        }
    }
}
