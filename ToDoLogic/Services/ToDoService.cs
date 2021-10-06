﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCommon.Entities;
using ToDoLogic.Models;

namespace ToDoLogic.Services
{
    public class ToDoService
    {
        private readonly ToDoDbContext _dbContext;
        private readonly IMapper _mapper;

        public ToDoService(ToDoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ToDoDto> GetNotDone()
        {
            var toDoes = _dbContext.ToDoes.Where(x => !x.IsDone).ToList();
            var toDoDtos = _mapper.Map<List<ToDoDto>>(toDoes);
            return toDoDtos;
        }

        public ToDoDto Details(int id)
        {
            var toDo = _dbContext.ToDoes.FirstOrDefault(x => x.Id == id);
            var result = _mapper.Map<ToDoDto>(toDo);
            return result;
        }

        public int Create(ToDoDto dto)
        {
            var toDo = _mapper.Map<ToDoDb>(dto);

            int lastId;
            if (_dbContext.ToDoes != null && !_dbContext.ToDoes.Any())
            {
                lastId = 1;
            }
            else
            {
                lastId = _dbContext.ToDoes.Max(x => x.Id) + 1;
            }
            toDo.Id = lastId;

            _dbContext.ToDoes.Add(toDo);
            _dbContext.SaveChanges();

            return toDo.Id;
        }
        public ToDoDb Edit(int id)
        {
            return _dbContext.ToDoes.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(int id, ToDoDto dto)
        {
            var toDo = _dbContext.ToDoes.FirstOrDefault(x => x.Id == id);

            toDo.Name = dto.Name;
            toDo.Description = dto.Description;
        }

        public ToDoDb Delete(int id)
        {
            return _dbContext.ToDoes.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id, ToDoDto toDoModels)
        {
            var toDo = _dbContext.ToDoes.FirstOrDefault(x => x.Id == id);

            _dbContext.ToDoes.Remove(toDo);
        }

        public void Done(int id)
        {
            var toDo = _dbContext.ToDoes.FirstOrDefault(x => x.Id == id);

            toDo.IsDone = true;
        }
    }
}
