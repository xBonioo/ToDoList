using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCommon.Entities
{
    public class ToDoDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=ToDoDb;Trusted_Connection=True;";

        public DbSet<ToDoDb> ToDoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoDb>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
