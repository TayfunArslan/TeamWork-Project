using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Service.Dto;
using TeamWork.Data.UnitOfWork;
using TeamWork.Service.Mapper;
using TeamWork.Data.Context;

namespace TeamWork.Service.Services
{
    public interface IProjectService
    {
        ProjectDto GetById(int id);
        void Add(ProjectDto dto);
        void Update(ProjectDto dto);
        void Delete(int id);
        List<ProjectDto> GetAll();
    }

    public class ProjectService : IProjectService
    {
        public void Add(ProjectDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<ProjectDto, Project>(dto);
                uow.GetRepository<Project>().Add(entity);
                uow.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.GetRepository<Project>().Delete(uow.GetRepository<Project>().GetById(id));
                uow.SaveChanges();
            }
        }

        public List<ProjectDto> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var list = uow.GetRepository<Project>().GetAll();
                return list.Select(MapperFactory.Map<Project, ProjectDto>).ToList();
            }
        }

        public ProjectDto GetById(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.GetRepository<Project>().GetById(id);
                return MapperFactory.Map<Project, ProjectDto>(entity);
            }
        }

        public void Update(ProjectDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<ProjectDto, Project>(dto);

                uow.GetRepository<Project>().Update(entity);
                uow.SaveChanges();
            }
        }

        public List<ProjectDto> GetActives()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var list = uow.GetRepository<Project>().GetAll();
                return list.Select(MapperFactory.Map<Project, ProjectDto>).ToList();
            }
        }
    }
}
