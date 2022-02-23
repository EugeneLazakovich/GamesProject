using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDAL
{
    public class EfCoreContext : DbContext
    {
        public DbSet<GameDto> Games { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<SaleDto> Sales { get; set; }
        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleDto>().HasKey(s => new { s.GameId, s.UserId });
        }
    }
}
