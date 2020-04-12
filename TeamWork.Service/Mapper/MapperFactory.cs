using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Data.Context;
using TeamWork.Service.Dto;

namespace TeamWork.Service.Mapper
{
    public static class MapperFactory
    {
        static MapperConfiguration mapperConfiguration;
        static bool _isInitialized;
        static object lck = new object();

        static void Init()
        {
            lock(lck)
            {
                if (_isInitialized) return;

                mapperConfiguration = new MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<Project, ProjectDto>();
                      cfg.CreateMap<Data.Context.Task, TaskDto>();
                      cfg.CreateMap<TaskHistory, TaskHistoryDto>();
                      cfg.CreateMap<Data.Context.TaskStatus, TaskStatusDto>();
                      cfg.CreateMap<User, UserDto>();
                      cfg.CreateMap<UserType, UserTypeDto>();

                      cfg.CreateMap<ProjectDto, Project>();
                      cfg.CreateMap<TaskDto, Data.Context.Task>();
                      cfg.CreateMap<TaskHistoryDto, TaskHistory>();
                      cfg.CreateMap<TaskStatusDto, Data.Context.TaskStatus>();
                      cfg.CreateMap<UserDto, User>();
                      cfg.CreateMap<UserTypeDto, UserType>();
                  });

                _isInitialized = true;
            }
        }

        public static K Map<T,K>(T input)
        {
            Init();

            IMapper mapper = mapperConfiguration.CreateMapper();

            return input != null ? mapper.Map<T, K>(input) : default(K);
        }
    }
}
