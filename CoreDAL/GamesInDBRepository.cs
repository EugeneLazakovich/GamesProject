using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreDAL
{   
    public class GamesInDBRepository : IGameRepository
    {
        private readonly EfCoreContext _dbContext;
        public GamesInDBRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid Add(GameDto game)
        {
            game.Id = Guid.NewGuid();
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return game.Id;
        }

        public IEnumerable<GameDto> GetAll()
        {
            return _dbContext.Games.ToList();
        }

        public GameDto GetById(Guid id)
        {
            return _dbContext.Games.FirstOrDefault(c => c.Id == id);
        }

        public GameDto RemoveById(Guid id)
        {
            var game = GetById(id);
            _dbContext.Games.Remove(game);
            _dbContext.SaveChanges();

            return game;
        }

        public bool UpdateById(GameDto game)
        {
            _dbContext.Games.Update(game);
            var result = _dbContext.SaveChanges();

            return result != 0;
        }
    }
}
