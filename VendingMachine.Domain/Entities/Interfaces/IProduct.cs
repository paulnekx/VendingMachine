using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.Core.Interfaces;

namespace VendingMachine.Domain.Entities.Interfaces
{
    public interface IProduct : IEntity
    {
        int Id { get; set; }

        int Quantity { get; set; }

        decimal Cost { get; set; }

        ReadOnlyCollection<IProduct> BasicIngredients { get; set; }

        ReadOnlyCollection<IProduct> Ingredients { get; }

        List<IProduct> OptionalIngredients { get; set; }
    }
}