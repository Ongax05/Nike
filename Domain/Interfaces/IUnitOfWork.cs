namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    Task<int> SaveAsync();
    ICategoriaProducto CategoriaProductos {get;}
    IOrden Ordenes {get;}
    IProducto Productos {get;}
    IOrdenProducto OrdenProductos{get;}
}
