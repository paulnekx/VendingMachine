using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    [DisplayName("Сахар")]
    public class Sugar : Product, IDrink, IIngredient
    {
    }
}
