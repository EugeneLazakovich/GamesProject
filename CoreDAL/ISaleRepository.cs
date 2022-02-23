using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDAL
{
    public interface ISaleRepository
    {
        Guid[] Add(SaleDto sale);
        IEnumerable<SaleDto> GetAll();
        SaleDto GetById(Guid gameId, Guid userId);
        SaleDto RemoveById(Guid gameId, Guid userId);
        bool UpdateById(SaleDto sale);
        IEnumerable<SaleDto> GetAllByUserAndToday(Guid userId);
    }
}
