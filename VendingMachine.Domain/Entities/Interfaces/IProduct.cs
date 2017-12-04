using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VendingMachine.Domain.Entities.Interfaces
{
    public interface IProduct
    {
        int Quantity { get; set; }

        decimal Cost { get; set; }

        ReadOnlyCollection<IIngredient> BasicIngredients { get; set; }

        ReadOnlyCollection<IIngredient> Ingredients { get; }

        List<IIngredient> OptionalIngredients { get; set; }
    }
}