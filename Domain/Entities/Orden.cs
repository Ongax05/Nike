using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Orden : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CantidadProductos { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<OrdenProducto> OrdenProductos { get; set; }
    }
}