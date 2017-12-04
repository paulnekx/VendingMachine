using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    [DisplayName("Сыр")]
    public class Cheese : Product, IFood, IIngredient
    {
    }
}
