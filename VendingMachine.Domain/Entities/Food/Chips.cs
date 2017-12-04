using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    [DisplayName("Чипсы")]
    public class Chips : Product, IFood
    {
    }
}
