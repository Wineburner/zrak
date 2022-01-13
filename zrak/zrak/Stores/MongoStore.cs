using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using zrak.Enumerators;
using zrak.Models;

namespace zrak.Stores
{
    public class MongoStore : IBlogStore, ITicTacToeStore
    {

        private readonly MongoClient _dbClient;
        private const string DataBaseName = "zrak";
        private const string BlogCollectionName = "blogs";
        private const string GameCollectionName = "games";
        public MongoStore(IConfiguration config) 
        {
            string connectionString = config["MongoDB"];
            _dbClient = new MongoClient(connectionString);
        }
        
        public void Create(BlogStoreModel blogStoreModel)
        {
            if (blogStoreModel.BlogId != null)
            {
                throw new Exception("Id must be null");
            }

            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<BlogStoreModel>(BlogCollectionName);
            collection.InsertOne(new BlogStoreModel
            {
                BlogId = Guid.NewGuid(),
                Title = blogStoreModel.Title,
                Body = blogStoreModel.Body
            });
            
        }

        public void Delete(Guid id)
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<BlogStoreModel>(BlogCollectionName);
            var filter = Builders<BlogStoreModel>.Filter.Eq("BlogId", id.ToString());

            collection.DeleteOne(filter);
        }

        public BlogStoreModel Read(Guid id)
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<BlogStoreModel>(BlogCollectionName);
            var filter = Builders<BlogStoreModel>.Filter.Eq("BlogId", id.ToString());

            return collection.Find(filter).FirstOrDefault();
        }

        public void Update(BlogStoreModel blogStoreModel)
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<BlogStoreModel>(BlogCollectionName);
            var filter = Builders<BlogStoreModel>.Filter.Eq("BlogId", blogStoreModel.BlogId.ToString());
            var update = Builders<BlogStoreModel>.Update.Set("BlogId", blogStoreModel.BlogId)
                                                        .Set("Title", blogStoreModel.Title)
                                                        .Set("Body", blogStoreModel.Body);

            collection.UpdateOne(filter, update);
        }

        public IEnumerable<BlogStoreModel> GetAllBlogs()
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<BlogStoreModel>(BlogCollectionName);

            return collection.Find(_ => true).ToList();
        }

        public void CreateGame(TicTacToeStoreModel ticTacToeStoreModel)
        {
            if (ticTacToeStoreModel.TicTacToeId != null)
            {
                throw new Exception("Id must be null");
            }

            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<TicTacToeStoreModel>(GameCollectionName);

            collection.InsertOne(new TicTacToeStoreModel
            {
                TicTacToeId = Guid.NewGuid(),
                BoardSpaces = new SpaceState[3, 3]
                {
                        {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                        {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                        {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty}
                },
                Turn = 'X',
                XWins = 0,
                OWins = 0,
                Ties = 0
            });
        }

        public void DeleteGame(Guid id)
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<TicTacToeStoreModel>(GameCollectionName);
            var filter = Builders<TicTacToeStoreModel>.Filter.Eq("TicTacToeId", id.ToString());

            collection.DeleteOne(filter);
        }

        public TicTacToeStoreModel ReadGame(Guid id)
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<TicTacToeStoreModel>(GameCollectionName);
            var filter = Builders<TicTacToeStoreModel>.Filter.Eq("TicTacToeId", id.ToString());

            return collection.Find(filter).FirstOrDefault();
        }

        public void UpdateGame(TicTacToeStoreModel ticTacToeStoreModel)
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<TicTacToeStoreModel>(GameCollectionName);
            var filter = Builders<TicTacToeStoreModel>.Filter.Eq("TicTacToeId", ticTacToeStoreModel.TicTacToeId.ToString());
            var update = Builders<TicTacToeStoreModel>.Update.Set("TicTacToeId", ticTacToeStoreModel.TicTacToeId)
                                                             .Set("XWins", ticTacToeStoreModel.XWins)
                                                             .Set("OWins", ticTacToeStoreModel.OWins)
                                                             .Set("Ties", ticTacToeStoreModel.Ties)
                                                             .Set("BoardSpaces", ticTacToeStoreModel.BoardSpaces)
                                                             .Set("Turn", ticTacToeStoreModel.Turn);

            collection.UpdateOne(filter, update);
        }

        public IEnumerable<TicTacToeStoreModel> GetAllGames()
        {
            var database = _dbClient.GetDatabase(DataBaseName);
            var collection = database.GetCollection<TicTacToeStoreModel>(GameCollectionName);

            return collection.Find(_ => true).ToList();
            
        }
    }
}
