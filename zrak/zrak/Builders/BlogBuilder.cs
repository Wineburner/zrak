﻿using MongoDB.Bson;
using System;
using zrak.Models;

namespace zrak.Builders
{
    public class BlogBuilder : IBlogBuilder
    {
        public BlogStoreModel Build(BlogModel blogModel)
        {
            if (blogModel.Id != null) 
            {
                return new BlogStoreModel
                {
                    Id = Guid.Parse(blogModel.Id),
                    Title = blogModel.Title,
                    Body = blogModel.Body,
                };
            }

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

        public BlogStoreModel Build(BsonDocument bsonDocument)
        {
            if (bsonDocument["ClientId"].ToString() != null)
            {
                return new BlogStoreModel
                {
                    Id = Guid.Parse(bsonDocument["ClientId"].ToString()),
                    Title = bsonDocument["Title"].ToString(),
                    Body = bsonDocument["Body"].ToString(),
                };
            }

            return new BlogStoreModel
            {
                Title = bsonDocument["Title"].ToString(),
                Body = bsonDocument["Body"].ToString(),
            };
        }
    }
}
