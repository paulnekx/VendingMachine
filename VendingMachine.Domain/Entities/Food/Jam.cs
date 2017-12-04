using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities.Food
{
    [DisplayName("Джем")]
    public class Jam : Product, IFood, IIngredient
    {
    }
}
