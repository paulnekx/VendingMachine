using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    [DisplayName("Молоко")]
    public class Milk : Product, IDrink, IIngredient
    {
    }
}
