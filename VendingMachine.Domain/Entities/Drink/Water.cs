using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    [DisplayName("Вода")]
    public class Water : Product, IDrink
    {
    }
}
