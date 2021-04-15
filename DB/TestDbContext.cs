using System;
using financeParse.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace financeParse.DB
{
    public class TestDbContext : DbContext
    {
        public DbSet<Info> Info { get; set; }
        public DbSet<Price> Price { get; set; }
        public TestDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=TestDb;User Id=user;Password=pass;MultipleActiveResultSets=true;Integrated Security=false");

    }
}
