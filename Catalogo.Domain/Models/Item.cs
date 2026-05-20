using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogoApp.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Consola { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public List<Review> Reviews { get; set; } = new List<Review>();

        // Propiedades calculadas
        public double PromedioEstrellas => Reviews.Count > 0 
            ? Reviews.Average(r => r.Estrellas) 
            : 0;
        public int TotalReviews => Reviews.Count;
    }
}
