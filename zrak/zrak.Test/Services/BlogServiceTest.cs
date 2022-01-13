using Moq;
using System;
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
            var title = "Breakfest";
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
            var title = "Breakfest";
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

        [Fact]
        public void Should_Edit_Blog_Successful() 
        {
            var title = "Breakfest";
            var body = "Bacon and Eggs";
            var id = "cc215e55-f44d-45cc-bba0-85acd951372f";
            var initModel = new BlogModel
            {
                Id = id,
                Title = title,
                Body = body
            };
            var correctModel = new BlogStoreModel
            {
                BlogId = Guid.Parse(id),
                Title = title,
                Body = body
            };
            var mockMemory = new Mock<IBlogStore>();
            var mockBuilder = new Mock<IBlogBuilder>();
            mockBuilder.Setup(x => x.Build(initModel)).Returns(correctModel);
            var service = new BlogService(mockMemory.Object, mockBuilder.Object);

            service.EditBlogPost(initModel);

            mockMemory.Verify(x => x.Update(correctModel));
        }

        [Fact]
        public void Should_Delete_Blog_Successful() 
        {
            var title = "Breakfest";
            var body = "Bacon and Eggs";
            var id = "cc215e55-f44d-45cc-bba0-85acd951372f";
            var initModel = new BlogModel
            {
                Id = id,
                Title = title,
                Body = body
            };
            var correctModel = new BlogStoreModel
            {
                BlogId = Guid.Parse(id),
                Title = title,
                Body = body
            };
            var mockMemory = new Mock<IBlogStore>();
            var mockBuilder = new Mock<IBlogBuilder>();
            mockBuilder.Setup(x => x.Build(initModel)).Returns(correctModel);
            var service = new BlogService(mockMemory.Object, mockBuilder.Object);

            service.DeleteBlogPost(id);

            mockMemory.Verify(x => x.Delete(Guid.Parse(id)));
        }
    }
}
