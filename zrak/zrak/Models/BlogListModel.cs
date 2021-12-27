using System.Collections.Generic;

namespace zrak.Models
{
    public class BlogListModel
    {
        public string Blogs { get; set; }

        public List<BlogStoreModel> List { get; set; }
    }
}
