using System;
using VendingMachine.Domain.Entities.Mappings;

namespace VendingMachine.Domain.Interfaces
{
    public interface IProductRepository : IRepository<ProductMap>, IDisposable
    {
    }
}
