using System.Collections.Generic;
using VendingMachine.Core.ExtensionMethods;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    public class Order
    {
        public List<IProduct> Products { get; set; }

        public bool IsCombo { get; set; }

        public Order()
        {
            Products = new List<IProduct>();
        }

        public decimal GetCost()
        {
            if (Products.IsNullOrEmpty())
            {
                return 0;
            }

            throw new System.NotImplementedException();
            return 0;
        }
    }
}
