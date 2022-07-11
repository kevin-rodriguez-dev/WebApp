using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public bool Status { get; set; } = true;
        public virtual ICollection<Producto> productos { get; set; }

    }
}
