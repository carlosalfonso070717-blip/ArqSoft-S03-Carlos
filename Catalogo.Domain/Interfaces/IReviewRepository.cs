using CatalogoApp.Domain.Models;
using System.Collections.Generic;

namespace CatalogoApp.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Review GetById(int id);
        List<Review> GetByItemId(int itemId);
        List<Review> GetByUserId(int userId);
        List<Review> GetAll();
        void Add(Review review);
        void Update(Review review);
        void Delete(int id);
    }
}
