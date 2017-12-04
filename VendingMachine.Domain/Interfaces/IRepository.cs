using System;
using System.Collections.Generic;
using VendingMachine.Core.Interfaces;

namespace VendingMachine.Domain.Interfaces
{
    public interface IRepository<TEnity> where TEnity : IEntity
    {
        IEnumerable<TEnity> Get();

        TEnity Get(int id);

        //TEnity GetBy(Func<TEnity, bool> predicate);
    }
}
