using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreDAL
{
    public class UsersInDBRepository : IUserRepository
    {
        private readonly EfCoreContext _dbContext;
        public UsersInDBRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid Add(UserDto user)
        {
            user.Id = Guid.NewGuid();
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public UserDto GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(c => c.Id == id);
        }

        public UserDto RemoveById(Guid id)
        {
            var user = GetById(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return user;
        }

        public bool UpdateById(UserDto user)
        {
            _dbContext.Users.Update(user);
            var result = _dbContext.SaveChanges();

            return result != 0;
        }
    }
}
