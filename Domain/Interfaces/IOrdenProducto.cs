using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrdenProducto
    {
        Task<OrdenProducto> GetByIdAsync(int id);
        Task<IEnumerable<OrdenProducto>> GetAllAsync();
        Task<(int totalRegisters, IEnumerable<OrdenProducto> registers)> GetAllAsync(
            int pageIndex,
            int pageSize
        );
        IEnumerable<OrdenProducto> Find(Expression<Func<OrdenProducto, bool>> expression);
        void Add(OrdenProducto entity);
        void AddRange(IEnumerable<OrdenProducto> entities);
        void Remove(OrdenProducto entity);
        void RemoveRange(IEnumerable<OrdenProducto> entities);
        void Update(OrdenProducto entity);
    }
}
