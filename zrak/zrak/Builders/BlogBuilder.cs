using zrak.Models;

namespace zrak.Builders
{
    public class BlogBuilder : IBlogBuilder
    {
        public BlogStoreModel Build(BlogModel blogModel)
        {
            return new BlogStoreModel
            {
                Title = blogModel.Title,
                Body = blogModel.Body,
            };
        }
    }
}
