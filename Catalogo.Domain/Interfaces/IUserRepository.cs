using CatalogoApp.Domain.Models;
using System.Collections.Generic;

namespace CatalogoApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByUsername(string username);
        User GetByEmail(string email);
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        bool ValidateCredentials(string username, string password);
    }
}
