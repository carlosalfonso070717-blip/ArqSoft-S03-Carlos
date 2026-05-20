using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CatalogoApp.Infrastructure.Repositories
{
    public class JsonReviewRepository : IReviewRepository
    {
        private readonly string _filePath;
        private List<Review> _reviews;

        public JsonReviewRepository(string filePath)
        {
            _filePath = filePath;
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists(_filePath))
            {
                _reviews = new List<Review>();
                SaveData();
            }
            else
            {
                var json = File.ReadAllText(_filePath);
                _reviews = JsonSerializer.Deserialize<List<Review>>(json) ?? new List<Review>();
            }
        }

        private void SaveData()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_reviews, options);
            File.WriteAllText(_filePath, json);
        }

        public Review GetById(int id)
        {
            return _reviews.FirstOrDefault(r => r.Id == id);
        }

        public List<Review> GetByItemId(int itemId)
        {
            return _reviews.Where(r => r.ItemId == itemId).OrderByDescending(r => r.FechaReview).ToList();
        }

        public List<Review> GetByUserId(int userId)
        {
            return _reviews.Where(r => r.UserId == userId).OrderByDescending(r => r.FechaReview).ToList();
        }

        public List<Review> GetAll()
        {
            return _reviews.ToList();
        }

        public void Add(Review review)
        {
            review.Id = _reviews.Any() ? _reviews.Max(r => r.Id) + 1 : 1;
            review.FechaReview = DateTime.Now;
            _reviews.Add(review);
            SaveData();
        }

        public void Update(Review review)
        {
            var existing = GetById(review.Id);
            if (existing != null)
            {
                var index = _reviews.IndexOf(existing);
                _reviews[index] = review;
                SaveData();
            }
        }

        public void Delete(int id)
        {
            var review = GetById(id);
            if (review != null)
            {
                _reviews.Remove(review);
                SaveData();
            }
        }
    }
}
