using zrak.Models;

namespace zrak.Builders
{
    public interface IBlogBuilder
    {
        BlogStoreModel Build(BlogModel blogModel);
        BlogModel Build(BlogStoreModel blogStoreModel);
        BlogStoreModel BuildId(BlogModel blogModel);
    }
}
