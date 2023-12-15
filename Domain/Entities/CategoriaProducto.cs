using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoriaProducto : BaseEntity
    {
        public string NombreCategoria { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}