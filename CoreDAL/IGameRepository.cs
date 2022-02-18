using CoreDAL.Entities;
using System;
using System.Collections.Generic;

namespace CoreDAL
{
    public interface IGameRepository
    {
        Guid Add(GameDto game);
        IEnumerable<GameDto> GetAll();
        GameDto GetById(Guid id);
        GameDto RemoveById(Guid id);
        bool UpdateById(GameDto game);
    }
}