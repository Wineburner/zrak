using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zrak.Builders;
using zrak.Enumerators;
using zrak.Mappers;
using zrak.Models;

namespace zrak.Stores
{
    public class MongoStore : IBlogStore, ITicTacToeStore
    {
        private readonly IBlogBuilder _blogBuilder;
        private readonly ITicTacToeBuilder _ticTacToeBuilder;
        private readonly MongoClient _dbClient;
        public MongoStore()
        {
            _blogBuilder = new BlogBuilder();
            _ticTacToeBuilder = new TicTacToeBuilder();
            _dbClient = new MongoClient("mongodb+srv://Devin:ZB3xI31fvdRc5dwW@tlo.u2egj.mongodb.net/zrak?retryWrites=true&w=majority");
        }

        public void Create(BlogStoreModel blogStoreModel)
        {
            if (blogStoreModel.Id != null)
            {
                throw new Exception("Id must be null");
            }

            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("blogs");

            var document = new BsonDocument()
            {
                {"ClientId", Guid.NewGuid().ToString() },
                {"Title", blogStoreModel.Title},
                {"Body", blogStoreModel.Body }
            };

            collection.InsertOne(document);
        }

        public void Delete(Guid id)
        {
            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("blogs");
            var filter = Builders<BsonDocument>.Filter.Eq("ClientId", id.ToString());

            collection.DeleteOne(filter);
        }

        public BlogStoreModel Read(Guid id)
        {
            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("blogs");
            var filter = Builders<BsonDocument>.Filter.Eq("ClientId", id.ToString());

            return _blogBuilder.Build(collection.Find(filter).FirstOrDefault());
        }

        public void Update(BlogStoreModel blogStoreModel)
        {

            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("blogs");
            var filter = Builders<BsonDocument>.Filter.Eq("ClientId", blogStoreModel.Id.ToString());
            var update = Builders<BsonDocument>.Update.Set( "Title", blogStoreModel.Title)
                                                      .Set("Body", blogStoreModel.Body);

            collection.UpdateOne(filter, update);
        }

        public IEnumerable<BlogStoreModel> GetAllBlogs()
        {
            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("blogs");
            var collectionList = collection.Find(new BsonDocument()).ToList();
            List<BlogStoreModel> modelList = new List<BlogStoreModel>();

            foreach (var blog in collectionList) 
            {
                modelList.Add(_blogBuilder.Build(blog));
            }

            return modelList;
        }

        public void CreateGame(TicTacToeStoreModel ticTacToeStoreModel)
        {
            if (ticTacToeStoreModel.Id != null)
            {
                throw new Exception("Id must be null");
            }

            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("games");

            var document = new BsonDocument()
            {
                { "ClientId", Guid.NewGuid().ToString() },
                { "0,0",  SpaceState.Empty},
                { "0,1",  SpaceState.Empty},
                { "0,2",  SpaceState.Empty},
                { "1,0",  SpaceState.Empty},
                { "1,1",  SpaceState.Empty},
                { "1,2",  SpaceState.Empty},
                { "2,0",  SpaceState.Empty},
                { "2,1",  SpaceState.Empty},
                { "2,2",  SpaceState.Empty},
                { "Turn", char.ToString('X') },
                { "XWins", 0 },
                { "OWins", 0},
                { "Ties", 0}
            };

            collection.InsertOne(document);
        }

        public void DeleteGame(Guid id)
        {
            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("games");
            var filter = Builders<BsonDocument>.Filter.Eq("ClientId", id.ToString());

            collection.DeleteOne(filter);
        }

        public TicTacToeStoreModel ReadGame(Guid id)
        {
            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("games");
            var filter = Builders<BsonDocument>.Filter.Eq("ClientId", id.ToString());
            
            return _ticTacToeBuilder.Build(collection.Find(filter).FirstOrDefault());
        }

        public void UpdateGame(TicTacToeStoreModel ticTacToeStoreModel)
        {

            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("games");
            var filter = Builders<BsonDocument>.Filter.Eq("ClientId", ticTacToeStoreModel.Id.ToString());
            var update = Builders<BsonDocument>.Update.Set("0,0", ticTacToeStoreModel.BoardSpaces[0, 0])
                                                      .Set("0,1", ticTacToeStoreModel.BoardSpaces[0, 1])
                                                      .Set("0,2", ticTacToeStoreModel.BoardSpaces[0, 2])
                                                      .Set("1,0", ticTacToeStoreModel.BoardSpaces[1, 0])
                                                      .Set("1,1", ticTacToeStoreModel.BoardSpaces[1, 1])
                                                      .Set("1,2", ticTacToeStoreModel.BoardSpaces[1, 2])
                                                      .Set("2,0", ticTacToeStoreModel.BoardSpaces[2, 0])
                                                      .Set("2,1", ticTacToeStoreModel.BoardSpaces[2, 1])
                                                      .Set("2,2", ticTacToeStoreModel.BoardSpaces[2, 2])
                                                      .Set("Turn", char.ToString(ticTacToeStoreModel.Turn))
                                                      .Set("XWins", ticTacToeStoreModel.XWins)
                                                      .Set("OWins", ticTacToeStoreModel.OWins)
                                                      .Set("Ties", ticTacToeStoreModel.Ties);

            collection.UpdateOne(filter, update);
        }

        public IEnumerable<TicTacToeStoreModel> GetAllGames()
        {
            var database = _dbClient.GetDatabase("zrak");
            var collection = database.GetCollection<BsonDocument>("games");
            var collectionList = collection.Find(new BsonDocument()).ToList();
            List<TicTacToeStoreModel> modelList = new List<TicTacToeStoreModel>();

            foreach (var game in collectionList)
            {
                modelList.Add(_ticTacToeBuilder.Build(game));
            }

            return modelList;
        }
    }
}
