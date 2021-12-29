using zrak.Models;
using zrak.Stores;
using zrak.Builders;
using System;
using System.Linq;

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
                Blogs = _blogStore.GetAllBlogs().Select(x => _blogBuilder.Build(x))
            };
        }

        public void AddBlogPost(BlogModel blogModel) 
        {
            _blogStore.Create(_blogBuilder.Build(blogModel));
        }

        public BlogModel ReadBlogPost(string id) 
        {
            var blogStore = _blogStore.Read(Guid.Parse(id));
            return _blogBuilder.Build(blogStore);
        }

        public void EditBlogPost(BlogModel blogModel) 
        {
            _blogStore.Update(_blogBuilder.BuildId(blogModel));
        }
    }
}
