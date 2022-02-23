using CoreDAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreDAL
{
    public class SalesInDBRepository : ISaleRepository
    {
        private readonly EfCoreContext _dbContext;
        public SalesInDBRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public void SqlQueryBuilder(string query)
        //{
        //    try
        //    {
        //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //        builder.DataSource = "DESKTOP-0Q7NADI\\SQLEXPRESS.database.windows.net";
        //        builder.UserID = "DESKTOP-0Q7NADI\\Пользователь";
        //        builder.Password = "";
        //        builder.InitialCatalog = "ITEADB";

        //        using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                connection.Open();                        
        //            }
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}

        public IEnumerable<SaleDto> GetAllByUserAndToday(Guid userId)
        {
            //var today = DateTime.Today.ToString("s").Substring(0, DateTime.Today.ToString("s").IndexOf("T"));
            var today = DateTime.Today;
            string query = String.Format("SELECT * FROM [dbo].[Sales] WHERE [UserId] = '{0}' AND [DateBuy] = '{1}'", userId.ToString(), today);
            var sales = _dbContext.Sales.FromSqlRaw(query).ToList();

            return sales;
        }
        public Guid[] Add(SaleDto sale)
        {
            _dbContext.Sales.Add(sale);
            _dbContext.SaveChanges();            

            return new Guid[]{sale.GameId, sale.UserId};
        }

        public IEnumerable<SaleDto> GetAll()
        {
            return _dbContext.Sales.ToList();
        }        

        public SaleDto GetById(Guid gameId, Guid userId)
        {
            var sale = _dbContext.Sales.FirstOrDefault(x => x.GameId == gameId && x.UserId == userId);

            return sale;
        }

        public SaleDto RemoveById(Guid gameId, Guid userId)
        {
            var sale = _dbContext.Sales.FirstOrDefault(x => x.GameId == gameId && x.UserId == userId);
            _dbContext.Remove(sale);
            _dbContext.SaveChanges();

            return sale;
        }

        public bool UpdateById(SaleDto sale)
        {
            _dbContext.Sales.Update(sale);
            var result = _dbContext.SaveChanges();

            return result != 0;
        }
    }
}
