using System;
using zrak.Models;

namespace zrak.Builders
{
    public class BlogBuilder : IBlogBuilder
    {
        public BlogStoreModel Build(BlogModel blogModel)
        {
            if (blogModel.Id != null) 
            {
                return new BlogStoreModel
                {
                    BlogId = Guid.Parse(blogModel.Id),
                    Title = blogModel.Title,
                    Body = blogModel.Body,
                };
            }

            return new BlogStoreModel
            {
                Title = blogModel.Title,
                Body = blogModel.Body,
            };
        }

        public BlogModel Build(BlogStoreModel blogStoreModel) 
        {
            return new BlogModel
            {
                Id = blogStoreModel.BlogId.ToString(),
                Title = blogStoreModel.Title,
                Body = blogStoreModel.Body
            };
        }
    }
}
