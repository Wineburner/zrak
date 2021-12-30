using System;
using zrak.Models;

namespace zrak.Services
{
    public interface IBlogService
    {
        BlogListModel GetBlog();

        void AddBlogPost(BlogModel blogModel);

        BlogModel ReadBlogPost(string id);

        void EditBlogPost(BlogModel blogModel);
    }
}
