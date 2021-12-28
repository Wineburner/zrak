using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using zrak.Builders;
using zrak.Models;
using zrak.Services;
using zrak.Stores;

namespace zrak.Test
{
    public class BlogServiceTest
    {
        [Fact]
        public void Should_Return_List_Successful()
        {
            var title = "ods vdf dde";
            var body = "Bacon and Eggs";
            var initModel = new BlogStoreModel
            {
                Title = title,
                Body = body
            };
            var correctModel = new BlogModel
            {
                Title = title,
                Body = body
            };
            var mockMemory = new Mock<IBlogStore>();
            mockMemory.Setup(x => x.GetAllBlogs()).Returns(new List<BlogStoreModel> { initModel });
            var mockBuilder = new Mock<IBlogBuilder>();
            mockBuilder.Setup(x => x.Build(initModel)).Returns(correctModel);
            var service = new BlogService(mockMemory.Object, mockBuilder.Object);

            var result = service.GetBlog();

            Assert.NotEmpty(result.Blogs);
            Assert.Equal(title, result.Blogs.ToList()[0].Title);
            Assert.Equal(body, result.Blogs.ToList()[0].Body);
        }

        [Fact]
        public void Should_Set_Blog_Successful()
        {
            var title = "ods vdf dde";
            var body = "Bacon and Eggs";
            var initModel = new BlogModel
            {
                Title = title,
                Body = body
            };
            var correctModel = new BlogStoreModel
            {
                Title = title,
                Body = body
            };
            var mockMemory = new Mock<IBlogStore>();
            var mockBuilder = new Mock<IBlogBuilder>();
            mockBuilder.Setup(x => x.Build(initModel)).Returns(correctModel);
            var service = new BlogService(mockMemory.Object, mockBuilder.Object);

            service.AddBlogPost(initModel);

            mockMemory.Verify(x => x.Create(correctModel));
        }
    }
}
