using System.Threading.Tasks;
using zrak.Models;
using zrak.Stores;

namespace zrak.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogStore _blogStore;

        public BlogService(IBlogStore blogStore) 
        {
            _blogStore = blogStore;
        }

        public BlogListModel GetBlog() 
        {
            return new BlogListModel()
            {
                Blogs = "Blogs",
                List = _blogStore.List()
            };
        }

        public void AddBlogPost(BlogModel blogModel) 
        {
            _blogStore.Create(new BlogStoreModel { 
                Title = blogModel.Title,
                Body = blogModel.Body,
            });
        }
    }
}
