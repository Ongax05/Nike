using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    public class OrdenProductoRepository : IOrdenProducto
    {
    private readonly ApiDbContext _context;

    public OrdenProductoRepository(ApiDbContext context)
    {
        _context = context;
    }
    public virtual void Add(OrdenProducto entity)
    {
        _context.Set<OrdenProducto>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<OrdenProducto> entities)
    {
        _context.Set<OrdenProducto>().AddRange(entities);
    }
    public virtual IEnumerable<OrdenProducto> Find(Expression<Func<OrdenProducto, bool>> expression)
    {
        return _context.Set<OrdenProducto>().Where(expression);
    }
    public virtual async Task<IEnumerable<OrdenProducto>> GetAllAsync()
    {
        return await _context.Set<OrdenProducto>().ToListAsync();
    }
    public virtual async Task<(int totalRegisters, IEnumerable<OrdenProducto> registers)> GetAllAsync (int pageIndex, int pageSize){
            var totalRegisters = await _context.Set<OrdenProducto>().CountAsync();
            var registers = await _context.Set<OrdenProducto>().Skip((pageIndex -1) * pageSize).Take(pageSize).ToListAsync();
            return (totalRegisters, registers);
        }
    public virtual async Task<OrdenProducto> GetByIdAsync(int id)
    {
        return await _context.Set<OrdenProducto>().FindAsync(id);
    }
    public virtual async Task<OrdenProducto> GetByIdAsync(string id)
    {
       return await _context.Set<OrdenProducto>().FindAsync(id);
    }
    public virtual void Remove(OrdenProducto entity)
    {
        _context.Set<OrdenProducto>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<OrdenProducto> entities)
    {
        _context.Set<OrdenProducto>().RemoveRange(entities);
    }
    public virtual void Update(OrdenProducto entity)
    {
        _context.Set<OrdenProducto>()
            .Update(entity);
    }
    }
}