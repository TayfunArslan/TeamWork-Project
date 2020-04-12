using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Data.UnitOfWork;
using TeamWork.Service.Dto;
using TeamWork.Service.Mapper;

namespace TeamWork.Service.Services
{
    public interface ITaskStatusService
    {
        TaskStatusDto GetById(int id);
        void Add(TaskStatusDto dto);
        void Update(TaskStatusDto dto);
        void Delete(int id);
        List<TaskStatusDto> GetAll();
    }

    public class TaskStatusService : ITaskStatusService
    {
        public void Add(TaskStatusDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<TaskStatusDto, TeamWork.Data.Context.TaskStatus>(dto);

                uow.GetRepository<TeamWork.Data.Context.TaskStatus>().Add(entity);
                uow.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.GetRepository<TeamWork.Data.Context.TaskStatus>().Delete(uow.GetRepository<TeamWork.Data.Context.TaskStatus>().GetById(id));

                uow.SaveChanges();
            }
        }

        public List<TaskStatusDto> GetAll()
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var list = uow.GetRepository<TeamWork.Data.Context.TaskStatus>().GetAll();
                return list.Select(MapperFactory.Map<TeamWork.Data.Context.TaskStatus, TaskStatusDto>).ToList();
            }
        }

        public TaskStatusDto GetById(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var entity = uow.GetRepository<TeamWork.Data.Context.TaskStatus>().GetById(id);
                return MapperFactory.Map<TeamWork.Data.Context.TaskStatus, TaskStatusDto>(entity);
            }
        }

        public void Update(TaskStatusDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<TaskStatusDto, TeamWork.Data.Context.TaskStatus>(dto);

                uow.GetRepository<TeamWork.Data.Context.TaskStatus>().Update(entity);
                uow.SaveChanges();
            }
        }
    }
}
