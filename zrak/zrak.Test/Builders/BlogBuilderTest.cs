using Xunit;
using zrak.Models;
using zrak.Builders;

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

    }
}
