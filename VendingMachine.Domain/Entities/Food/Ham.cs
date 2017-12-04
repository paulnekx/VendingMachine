using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    [DisplayName("Ветчина")]
    public class Ham : Product, IFood, IIngredient
    {
    }
}
