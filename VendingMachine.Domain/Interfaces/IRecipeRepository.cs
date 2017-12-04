using System;
using VendingMachine.Domain.Entities.Mappings;

namespace VendingMachine.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<RecipeMap>, IDisposable
    {
    }
}
