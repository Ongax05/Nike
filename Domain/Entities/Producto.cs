using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto : BaseEntity
    {
        public int CategoriaProductoId { get; set; }
        public CategoriaProducto CategoriaProducto { get; set; }
        public string NombreProducto { get; set; }
        public byte[] Imagen { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public ICollection<OrdenProducto> OrdenProductos { get; set; }
    }
}