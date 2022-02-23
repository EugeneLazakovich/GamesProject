using AutoMapper;
using CoreDAL;
using CoreDAL.Entities;
using GamesHM1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL
{
    public class SaleService
    {
        private ISaleRepository _saleRepository;
        private IMapper _mapper;

        public SaleService(IMapper mapper, ISaleRepository saleRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }
        public Guid[] AddSale(Guid gameId, Guid userId, decimal price)
        {
            if(gameId == null)
            {
                gameId = Guid.NewGuid();
            }
            if (userId == null)
            {
                userId = Guid.NewGuid();
            }
            var sale = new Sale()
            {
                GameId = gameId,
                UserId = userId,
                DateBuy = DateTime.Now,
                Price = price
            };
            if (sale.Price < 0)
            {
                throw new ArgumentException("Price can't be less than 0!");
            }
            var dBSale = _mapper.Map<SaleDto>(sale);

            return _saleRepository.Add(dBSale);
        }

        public IEnumerable<Sale> GetAllSales()
        {   
            var sales = _mapper.Map<IEnumerable<Sale>>(_saleRepository.GetAll());

            return sales;
        }

        public Sale GetById(Guid gameId, Guid userId)
        {
            var dbSale = _saleRepository.GetById(gameId, userId);
            var sale = _mapper.Map<Sale>(dbSale);

            return sale;
        }

        public Sale RemoveById(Guid gameId, Guid userId)
        {
            var dbSale = _saleRepository.RemoveById(gameId, userId);
            var sale = _mapper.Map<Sale>(dbSale);

            return sale;
        }

        public bool UpdateById(Sale sale)
        {
            return _saleRepository.UpdateById(_mapper.Map<SaleDto>(sale));
        }

        public IEnumerable<Sale> GetAllByUserAndToday(Guid userId)
        {
            var sales = _mapper.Map<IEnumerable<Sale>>(_saleRepository.GetAllByUserAndToday(userId));

            return sales;
        }
    }
}
