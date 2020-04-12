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
    public interface IUserService
    {
        UserDto GetById(int id);
        void Add(UserDto dto);
        void Update(UserDto dto);
        void Delete(int id);
        List<UserDto> GetAll();
        UserDto Login(string username,string password);
    }

    public class UserService : IUserService
    {
        public void Add(UserDto dto)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var entity = MapperFactory.Map<UserDto, User>(dto);
                uow.GetRepository<User>().Add(entity);
                uow.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                uow.GetRepository<User>().Delete(uow.GetRepository<User>().GetById(id));
                uow.SaveChanges();
            }
        }

        public List<UserDto> GetAll()
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var list = uow.GetRepository<User>().GetAll();
                return list.Select(MapperFactory.Map<User, UserDto>).ToList();
            }
        }

        public UserDto GetById(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var entity = uow.GetRepository<User>().GetById(id);
                return MapperFactory.Map<User, UserDto>(entity);
            }
        }

        public UserDto Login(string username, string password)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var entity = uow.GetRepository<User>().GetAll().Where(p => p.Username == username && p.Password == password).FirstOrDefault();
                return MapperFactory.Map<User, UserDto>(entity);
            }
        }

        public void Update(UserDto dto)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                var entity = MapperFactory.Map<UserDto, User>(dto);
                uow.GetRepository<User>().Update(entity);
                uow.SaveChanges();
            }
        }
    }
}
