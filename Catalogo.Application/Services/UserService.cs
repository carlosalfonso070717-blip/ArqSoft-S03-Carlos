using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;
using System.Collections.Generic;

namespace CatalogoApp.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public bool Register(string username, string email, string password)
        {
            // Verificar si el usuario ya existe
            if (_userRepository.GetByUsername(username) != null)
                return false;

            if (_userRepository.GetByEmail(email) != null)
                return false;

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password // En producción, esto debería estar hasheado
            };

            _userRepository.Add(user);
            return true;
        }

        public User Login(string username, string password)
        {
            if (_userRepository.ValidateCredentials(username, password))
            {
                return _userRepository.GetByUsername(username);
            }
            return null;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
