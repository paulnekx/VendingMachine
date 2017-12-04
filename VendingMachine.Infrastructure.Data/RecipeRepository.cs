using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.Entities.Mappings;
using VendingMachine.Domain.Interfaces;

namespace VendingMachine.Infrastructure.Data
{
    public class RecipeRepository : Repository<RecipeMap>, IRecipeRepository
    {
        public override IEnumerable<RecipeMap> Get()
        {
            return TestValues.Reciepts;
        }

        public override RecipeMap Get(int id)
        {
            return TestValues.Reciepts.FirstOrDefault(l => l.Id == id);
        }

        void IDisposable.Dispose()
        {
            //DbContext's, connection
        }
    }
}
