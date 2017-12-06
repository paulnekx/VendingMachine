using System.Collections.Generic;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    public class Menu : Dictionary<IProduct, IEnumerable<IProduct>>
    {
        
    }
}
