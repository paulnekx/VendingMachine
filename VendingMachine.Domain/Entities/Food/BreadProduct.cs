using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    public abstract class BreadProduct : Product, IFood, IIngredient
    {
    }
}
