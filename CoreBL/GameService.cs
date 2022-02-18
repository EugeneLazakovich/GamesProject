using GamesHM1.Models;
using CoreDAL;
using System;
using System.Collections.Generic;
using AutoMapper;
using CoreDAL.Entities;

namespace CoreBL
{
    public class GameService
    {
        private IGameRepository _gameRepository;
        private IMapper _mapper;

        public GameService(IMapper mapper, IGameRepository gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }
        public Guid AddGame(Game game)
        {
            if (!char.IsUpper(game.Name[0]))
            {
                throw new ArgumentException("Name should starts with upper-case!");
            }
            var dBGame = _mapper.Map<GameDto>(game);

            return _gameRepository.Add(dBGame);            
        }

        public IEnumerable<Game> GetAllGames()
        {
            var dbGames = _gameRepository.GetAll();
            var games = _mapper.Map<IEnumerable<Game>>(dbGames);

            return games;
        }

        public Game GetGameById(Guid id)
        {
            var dbGame = _gameRepository.GetById(id);
            var game = _mapper.Map<Game>(dbGame);

            return game;
        }

        public Game RemoveGame(Guid id)
        {
            var dbGame = _gameRepository.RemoveById(id);
            var game = _mapper.Map<Game>(dbGame);

            return game;
        }

        public bool UpdateGame(Game game)
        {
            return _gameRepository.UpdateById(_mapper.Map<GameDto>(game));
        }
    }
}
