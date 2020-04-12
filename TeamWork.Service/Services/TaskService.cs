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
    public interface ITaskService
    {
        TaskDto GetById(int id);
        void Add(TaskDto dto);
        void Delete(int id);
        void Update(TaskDto dto);
        List<TaskDto> GetAll();
        List<TaskDto> Search(TaskSearchDto dto);
    }

    public class TaskService : ITaskService
    {
        public void Add(TaskDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<TaskDto, TeamWork.Data.Context.Task>(dto);
                uow.GetRepository<Data.Context.Task>().Add(entity);
                uow.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.GetRepository<Data.Context.Task>().GetById(id);
                uow.GetRepository<Data.Context.Task>().Delete(entity);
                uow.SaveChanges();
            }
        }

        public List<TaskDto> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var list = uow.GetRepository<Data.Context.Task>().GetAll().ToList();
                return list.Select(MapperFactory.Map<Data.Context.Task, TaskDto>).ToList();
            }
        }

        public TaskDto GetById(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.GetRepository<Data.Context.Task>().GetById(id);
                return MapperFactory.Map<Data.Context.Task, TaskDto>(entity);
            }
        }

        public List<TaskDto> Search(TaskSearchDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var list = uow.GetRepository<Data.Context.Task>().GetAll();

                //Ekrandan proje seçilmişse filtre olarak eklenecek
                if (dto.ProjectId > 0)
                    list = list.Where(p => p.ProjectId == dto.ProjectId);

                //Ekrandan statü seçilmişse filtre olarak eklenecek
                if (dto.TaskStatusId > 0)
                    list = list.Where(p => p.TaskStatusId == dto.TaskStatusId);

                //Ekrandan kişi seçilmişse filtre olarak eklenecek
                if (dto.UserId > 0)
                    list = list.Where(p => p.AssignTo == dto.UserId);

                return list.Select(MapperFactory.Map<Data.Context.Task, TaskDto>).ToList();
            }
        }

        public void Update(TaskDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<TaskDto, Data.Context.Task>(dto);
                uow.GetRepository<Data.Context.Task>().Update(entity);
                uow.SaveChanges();
            }
        }
    }
}
