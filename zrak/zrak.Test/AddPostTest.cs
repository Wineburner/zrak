using Xunit;
using zrak.Services;
using zrak.Stores;
using zrak.Models;
using zrak.Controllers;

namespace zrak.Test
{
    public class AddPostTest
    {

        [Fact]
        public void Is_Post_Added()
        {
            var memory = new InMemoryStore();

            var service = new BlogService(memory);

            var controller = new BlogController(service);

            var model = new BlogModel();
            model.Title = "Title";
            model.Body = "Body";

            controller.AddPost(model);

            var result = service.GetBlog();


            Assert.NotEmpty(result.List);

        }
    }
}
