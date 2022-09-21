using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Infastructure.Dto;

namespace ToDo.Infastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ListOfTasks, ListOfTasksDto>();
                //cfg.CreateMap<ListOfTasksDto, ListOfTasks>();
                cfg.CreateMap<TaskFromList, TaskFromListDto>();
                cfg.CreateMap<ListOfTasksModel, ListOfTasks>();

            }

        ).CreateMapper();
        
    }
}
