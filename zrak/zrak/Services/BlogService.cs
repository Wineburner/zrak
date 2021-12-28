using zrak.Models;
using zrak.Stores;
using zrak.Builders;

namespace zrak.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogStore _blogStore;
        private readonly IBlogBuilder _blogBuilder;

        public BlogService(IBlogStore blogStore, IBlogBuilder blogBuilder) 
        {
            _blogStore = blogStore;
            _blogBuilder = blogBuilder;
        }

        public BlogListModel GetBlog() 
        {
            return new BlogListModel()
            {
                Blogs = "Blogs",
                List = _blogStore.GetAllBlogs()
            };
        }

        public void AddBlogPost(BlogModel blogModel) 
        {
            _blogStore.Create(_blogBuilder.Build(blogModel));
        }
    }
}
