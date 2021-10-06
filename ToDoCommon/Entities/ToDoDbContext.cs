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
        public DbSet<ToDoDb> ToDoes { get; set; }

        public ToDoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoDb>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
