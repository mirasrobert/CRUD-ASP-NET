using CRUD_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP.Context
{
    public class MYContext : DbContext
    {
        public MYContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        // If you want to add another Models
        // public DbSet<AnotherModel> AnotherModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=D:\Code\CRUD_ASP\CRUD_ASP\DB\mydb.db");



    }
}
