using System.Collections.Generic;

namespace zrak.Models
{
    public class BlogListModel
    {
        public string Blogs { get; set; }

        public IEnumerable<BlogStoreModel> List { get; set; }

        public BlogStoreModel Selected { get; set; }
    }
}
