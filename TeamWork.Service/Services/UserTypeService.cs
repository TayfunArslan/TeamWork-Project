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
    public interface IUserTypeService
    {
        UserTypeDto GetById(int id);
        void Add(UserTypeDto dto);
        void Update(UserTypeDto dto);
        void Delete(int id);
        List<UserTypeDto> GetAll();
    }

    public class UserTypeService : IUserTypeService
    {
        public void Add(UserTypeDto dto)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var entity = MapperFactory.Map<UserTypeDto, UserType>(dto);
                uow.GetRepository<UserType>().Add(entity);
                uow.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                uow.GetRepository<UserType>().Delete(uow.GetRepository<UserType>().GetById(id));
                uow.SaveChanges();
            }
        }

        public List<UserTypeDto> GetAll()
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var list = uow.GetRepository<UserType>().GetAll();
                return list.Select(MapperFactory.Map<UserType, UserTypeDto>).ToList();
            }
        }

        public UserTypeDto GetById(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var entity = uow.GetRepository<UserType>().GetById(id);
                return MapperFactory.Map<UserType, UserTypeDto>(entity);
            }
        }

        public void Update(UserTypeDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = MapperFactory.Map<UserTypeDto, UserType>(dto);

                uow.GetRepository<UserType>().Update(entity);
                uow.SaveChanges();
            }
        }
    }
}