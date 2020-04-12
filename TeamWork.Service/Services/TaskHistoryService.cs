using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Data.Context;
using TeamWork.Data.UnitOfWork;
using TeamWork.Service.Dto;
using TeamWork.Service.Mapper;

namespace TeamWork.Service.Services
{
    public interface ITaskHistoryService
    {
        TaskHistoryDto GetById(int id);
        void Add(TaskHistoryDto dto);
        void Update(TaskHistoryDto dto);
        void Delete(int id);
        List<TaskHistoryDto> GetAll();
    }

    public class TaskHistoryService : ITaskHistoryService
    {
        public void Add(TaskHistoryDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<TaskHistoryDto, TaskHistory>(dto);
                uow.GetRepository<TaskHistory>().Add(entity);
                uow.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                TaskHistory entity = uow.GetRepository<TaskHistory>().GetById(id);
                uow.GetRepository<TaskHistory>().Delete(entity);
            }
        }

        public List<TaskHistoryDto> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var list = uow.GetRepository<TaskHistory>().GetAll();
                return list.Select(MapperFactory.Map<TaskHistory, TaskHistoryDto>).ToList();
            }
        }

        public TaskHistoryDto GetById(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.GetRepository<TaskHistory>().GetById(id);
                return MapperFactory.Map<TaskHistory, TaskHistoryDto>(entity);
            }
        }

        public void Update(TaskHistoryDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<TaskHistoryDto, TaskHistory>(dto);
                uow.GetRepository<TaskHistory>().Update(entity);
                uow.SaveChanges();
            }
        }
    }
}
