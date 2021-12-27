using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zrak.Models;

namespace zrak.Stores
{
    public class InMemoryStore : IBlogStore
    {
        private readonly List<BlogStoreModel> _blogStoreModel;

        public InMemoryStore() 
        {
            _blogStoreModel = new List<BlogStoreModel>();
        }

        public void Create(BlogStoreModel blogStoreModel)
        {
            if (blogStoreModel.Id != null) 
            {
                throw new Exception("Id must be null");
            }

            _blogStoreModel.Add(new BlogStoreModel
            {
                Id = Guid.NewGuid(),
                Title = blogStoreModel.Title,
                Body = blogStoreModel.Body
            });
        }

        public void Delete(Guid id)
        {
            _blogStoreModel.RemoveAll(x => x.Id == id);
        }

        public BlogStoreModel Read(Guid id)
        {
            return _blogStoreModel.FirstOrDefault(x => x.Id == id);
        }

        public void Update(BlogStoreModel blogStoreModel)
        {
            var found = _blogStoreModel.FirstOrDefault(x => x.Id == blogStoreModel.Id);

            if (found == null) 
            {
                throw new Exception("Id was null");
            }

            found.Title = blogStoreModel.Title;
            found.Body = blogStoreModel.Body;
        }

        public List<BlogStoreModel> List() 
        {
            return _blogStoreModel;
        }
    }
}
