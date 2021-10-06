using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoCommon.Entities;
using ToDoLogic.Models;

namespace ToDo
{
    public class ToDoMappingProfile : Profile
    {
        public ToDoMappingProfile()
        {
            CreateMap<ToDoDb, ToDoDto>()
                .ForMember(x => x.Name, n => n.MapFrom(c => c.Name))
                .ForMember(x => x.Description, n => n.MapFrom(c => c.Description))
                .ForMember(x => x.IsDone, n => n.MapFrom(c => c.IsDone));

            CreateMap<ToDoDto, ToDoDb>()
                .ForMember(x => x.Name, n => n.MapFrom(c => c.Name))
                .ForMember(x => x.Description, n => n.MapFrom(c => c.Description))
                .ForMember(x => x.IsDone, n => n.MapFrom(c => c.IsDone));
        }
    }
}
