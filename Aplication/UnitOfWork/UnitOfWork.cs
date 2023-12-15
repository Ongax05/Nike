using Aplication.Repository;
using Domain.Interfaces;
using Persistency;
namespace Aplication.UnitOfWork;
public class UnitOfWork(ApiDbContext context) : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context = context;

    private IRolRepository _roles;
    public IRolRepository Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
    }
    private IUserRepository _users;

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    private IOrdenProducto _OrdenProductos;
    public IOrdenProducto OrdenProductos
    {
        get
        {
            _OrdenProductos ??= new OrdenProductoRepository(_context);
            return _OrdenProductos;
        }
    }
    private IProducto _Productos;
    public IProducto Productos
    {
        get
        {
            _Productos ??= new ProductoRepository(_context);
            return _Productos;
        }
    }
    private ICategoriaProducto _CategoriaProductos;
    public ICategoriaProducto CategoriaProductos
    {
        get
        {
            _CategoriaProductos ??= new CategoriaProductoRepository(_context);
            return _CategoriaProductos;
        }
    }
    private IOrden _Ordenes;
    public IOrden Ordenes
    {
        get
        {
            _Ordenes ??= new OrdenRepository(_context);
            return _Ordenes;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
