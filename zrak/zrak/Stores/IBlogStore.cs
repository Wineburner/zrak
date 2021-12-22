using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zrak.Models;

namespace zrak.Stores
{
    public interface IBlogStore
    {
        void Create(BlogStoreModel blogStoreModel);
        BlogStoreModel Read(Guid id);
        void Update(BlogStoreModel blogStoreModel);
        void Delete(Guid id);
    }
}
