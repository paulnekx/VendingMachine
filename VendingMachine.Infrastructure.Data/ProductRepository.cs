using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.Entities.Mappings;
using VendingMachine.Domain.Interfaces;

namespace VendingMachine.Infrastructure.Data
{
    public class ProductRepository : Repository<ProductMap>, IProductRepository
    {
        public override IEnumerable<ProductMap> Get()
        {
            return TestValues.Products;
        }

        public override ProductMap Get(int id)
        {
            return TestValues.Products.FirstOrDefault(l => l.Id == id);
        }

        public void Dispose()
        {
            //DbContext's, connection
        }
    }
}
