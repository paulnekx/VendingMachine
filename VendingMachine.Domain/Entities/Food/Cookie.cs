using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    [DisplayName("Печенье")]
    public class Cookie : Product, IFood
    {
    }
}
