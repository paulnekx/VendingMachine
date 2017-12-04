using System.Collections.Generic;
using VendingMachine.Core.Interfaces;
using VendingMachine.Domain.Interfaces;

namespace VendingMachine.Infrastructure.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        protected bool disposedValue = false;

        public abstract IEnumerable<TEntity> Get();

        public abstract TEntity Get(int id);
    }
}
