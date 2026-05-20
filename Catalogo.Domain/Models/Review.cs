using System;

namespace CatalogoApp.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Estrellas { get; set; } // 1-5
        public string Comentario { get; set; } = string.Empty;
        public DateTime FechaReview { get; set; } = DateTime.Now;
    }
}
