using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoCommon.Entities;
using ToDoLogic.Models;
using ToDoLogic.Services;

namespace ToDo
{
    public class ToDoSeeder
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoSeeder(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigration = _dbContext.Database.GetPendingMigrations();
                if (pendingMigration != null && pendingMigration.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.ToDoes.Any())
                {
                    var toDo = GetToDo();
                    _dbContext.ToDoes.AddRange(toDo);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<ToDoDb> GetToDo()
        {
            var toDoes = new List<ToDoDb>()
            {
                new ToDoDb(){ Name = "First test ToDo", Description = "Godzina 12:00", IsDone = false},
                new ToDoDb(){ Name = "Secound test ToDo", Description = "Godzina 12:00", IsDone = false }
            };

            return toDoes;
        }
    }
}
