using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;
using System.Collections.Generic;

namespace CatalogoApp.Application.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        public List<Review> GetReviewsByItem(int itemId)
        {
            return _reviewRepository.GetByItemId(itemId);
        }

        public bool AddReview(int itemId, int userId, int estrellas, string comentario)
        {
            if (estrellas < 1 || estrellas > 5)
                return false;

            var user = _userRepository.GetById(userId);
            if (user == null)
                return false;

            var review = new Review
            {
                ItemId = itemId,
                UserId = userId,
                Username = user.Username,
                Estrellas = estrellas,
                Comentario = comentario
            };

            _reviewRepository.Add(review);
            return true;
        }

        public List<Review> GetUserReviews(int userId)
        {
            return _reviewRepository.GetByUserId(userId);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewRepository.Delete(reviewId);
        }
    }
}
