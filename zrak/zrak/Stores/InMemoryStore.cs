﻿using System;
using System.Collections.Generic;
using System.Linq;
using zrak.Models;
using zrak.Enumerators;
using static zrak.Enumerators.TicTacToeEnumerator;

namespace zrak.Stores
{
    public class InMemoryStore : IBlogStore, ITicTacToeStore
    {
        private readonly List<BlogStoreModel> _blogStoreModel;
        private readonly List<TicTacToeStoreModel> _ticTacToeStoreModel;
        private readonly List<TicTacToeEnumerator> _ticTacToeEnumator;

        public InMemoryStore() 
        {
            _blogStoreModel = new List<BlogStoreModel>();
            _ticTacToeStoreModel = new List<TicTacToeStoreModel>();
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

        public IEnumerable<BlogStoreModel> GetAllBlogs() 
        {
            return _blogStoreModel;
        }
        public void CreateGame(TicTacToeStoreModel ticTacToeStoreModel)
        {
            if (ticTacToeStoreModel.Id != null)
            {
                throw new Exception("Id must be null");
            }

            _ticTacToeStoreModel.Add(new TicTacToeStoreModel
            {
                Id = Guid.NewGuid(),
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
            }) ;
        }

        public void DeleteGame(Guid id)
        {
            _ticTacToeStoreModel.RemoveAll(x => x.Id == id);
        }

        public TicTacToeStoreModel ReadGame(Guid id)
        {
            return _ticTacToeStoreModel.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateGame(TicTacToeStoreModel ticTacToeStoreModel)
        {
            var found = _ticTacToeStoreModel.FirstOrDefault(x => x.Id == ticTacToeStoreModel.Id);

            if (found == null)
            {
                throw new Exception("Id was null");
            }

            found.Id = ticTacToeStoreModel.Id;
            found.BoardSpaces = ticTacToeStoreModel.BoardSpaces;
            found.Turn = ticTacToeStoreModel.Turn;
            found.XWins = ticTacToeStoreModel.XWins;
            found.OWins = ticTacToeStoreModel.OWins;
            found.Ties = ticTacToeStoreModel.Ties;
        }

        public IEnumerable<TicTacToeStoreModel> GetAllGames()
        {
            return _ticTacToeStoreModel;
        }
    }
}
