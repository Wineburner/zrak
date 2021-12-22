using Xunit;
using zrak.Services;
using zrak.Stores;

namespace zrak.Test
{
    public class BlogServiceTest
    {
        [Fact]
        public void Should_Say_Blog_Successful()
        {
            var service = new BlogService(new InMemoryStore());

            var result = service.GetBlog();

            Assert.Equal("Blogs", result.Blogs);

        }
    }
}
