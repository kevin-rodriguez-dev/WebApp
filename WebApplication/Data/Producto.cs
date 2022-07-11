using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public int CategoriaId { get; set; }
        public Categoria categorias { get; set; }

    }
}
