using AutoMapper;
using CoreDAL;
using CoreDAL.Entities;
using GamesHM1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public Guid AddUser(User user)
        {
            if (!char.IsUpper(user.Name[0]))
            {
                throw new ArgumentException("Name should starts with upper-case!");
            }
            var dBUser = _mapper.Map<UserDto>(user);

            return _userRepository.Add(dBUser);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var dbUsers = _userRepository.GetAll();
            var users = _mapper.Map<IEnumerable<User>>(dbUsers);

            return users;
        }

        public User GetUserById(Guid id)
        {
            var dbUser = _userRepository.GetById(id);
            var user = _mapper.Map<User>(dbUser);

            return user;
        }

        public User RemoveUser(Guid id)
        {
            var dbUser = _userRepository.RemoveById(id);
            var user = _mapper.Map<User>(dbUser);

            return user;
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateById(_mapper.Map<UserDto>(user));
        }
    }
}
