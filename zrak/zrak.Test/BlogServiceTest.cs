using Xunit;
using zrak.Services;

namespace zrak.Test
{
    public class BlogServiceTest
    {
        [Fact]
        public void Should_Say_Blog_Successful()
        {
            var service = new BlogService();

            var result = service.GetBlog();

            Assert.Equal("Blogs", result.Blog);

        }
    }
}
