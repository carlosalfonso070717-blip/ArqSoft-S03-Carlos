using System.ComponentModel.DataAnnotations;

namespace Catalogo.Presentation.Models
{
    public class ReviewViewModel
    {
        public int ItemId { get; set; }
        public string ItemTitulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debes seleccionar una calificación")]
        [Range(1, 5, ErrorMessage = "La calificación debe ser entre 1 y 5 estrellas")]
        public int Estrellas { get; set; }

        [Required(ErrorMessage = "El comentario es requerido")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "El comentario debe tener entre 10 y 500 caracteres")]
        public string Comentario { get; set; } = string.Empty;
    }
}
