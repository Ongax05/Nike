using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrdenProducto
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        public int Cantidad { get; set; }
    }
}