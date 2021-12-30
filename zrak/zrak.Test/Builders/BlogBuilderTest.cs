using Xunit;
using zrak.Models;
using zrak.Builders;
using System;

namespace zrak.Test.Builders
{
    public class BlogBuilderTest
    {
        [Fact]
        public void Should_Build_BlogStoreModel_From_BlogStore_Successful()
        {
            var title = "ods vdf dde";
            var body = "Bacon and Eggs";
            var initModel = new BlogModel
            {
                Title = title,
                Body = body
            };
            var builder = new BlogBuilder();

            var result = builder.Build(initModel);

            Assert.Equal(title, result.Title);
            Assert.Equal(body, result.Body);
        }

        [Fact]
        public void Should_Build_BlogModel_From_BlogStoreModel_Successful()
        {
            var title = "ods vdf dde";
            var body = "Bacon and Eggs";
            var initModel = new BlogStoreModel
            {
                Title = title,
                Body = body
            };
            var builder = new BlogBuilder();

            var result = builder.Build(initModel);

            Assert.Equal(title, result.Title);
            Assert.Equal(body, result.Body);
        }

        [Fact]
        public void Should_Build_BlogStoreModel_From_BlogModel_Successful_With_Id()
        {
            var title = "ods vdf dde";
            var body = "Bacon and Eggs";
            var id = "cc215e55-f44d-45cc-bba0-85acd951372f";
            var initModel = new BlogModel
            {
                Id = id,
                Title = title,
                Body = body
            };
            var builder = new BlogBuilder();

            var result = builder.BuildId(initModel);

            Assert.Equal(id, result.Id.ToString());
            Assert.Equal(title, result.Title);
            Assert.Equal(body, result.Body);
        }
    }
}
