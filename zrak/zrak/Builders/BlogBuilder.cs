﻿using System;
using zrak.Models;

namespace zrak.Builders
{
    public class BlogBuilder : IBlogBuilder
    {
        public BlogStoreModel Build(BlogModel blogModel)
        {
            return new BlogStoreModel
            {
                Title = blogModel.Title,
                Body = blogModel.Body,
            };
        }

        public BlogModel Build(BlogStoreModel blogStoreModel) 
        {
            return new BlogModel
            {
                Id = blogStoreModel.Id.ToString(),
                Title = blogStoreModel.Title,
                Body = blogStoreModel.Body
            };
        }

        public BlogStoreModel BuildId(BlogModel blogModel)
        {
            return new BlogStoreModel
            {
                Id = Guid.Parse(blogModel.Id),
                Title = blogModel.Title,
                Body = blogModel.Body,
            };
        }
    }
}
