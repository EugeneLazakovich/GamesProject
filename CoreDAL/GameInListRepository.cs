using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDAL
{
    public class GameInListRepository : IGameRepository
    {
        private static List<GameDto> _games;

        static GameInListRepository()
        {
            _games = new List<GameDto>();
        }

        public Guid Add(GameDto game)
        {
            game.Id = Guid.NewGuid();
            _games.Add(game);

            return game.Id;
        }
        public IEnumerable<GameDto> GetAll()
        {
            return _games;
        }
        public GameDto GetById(Guid id)
        {
            return _games.FirstOrDefault(c => c.Id == id);
        }
        public GameDto RemoveById(Guid id)
        {
            var game = GetById(id);
            _games.Remove(game);
            return game;
        }
        public bool UpdateById(GameDto game)
        {
            var dbGame = GetById(game.Id);
            if (dbGame != null)
            {
                var index = _games.IndexOf(dbGame);
                _games[index] = game;
            }
            return dbGame != null;
        }
    }
}
