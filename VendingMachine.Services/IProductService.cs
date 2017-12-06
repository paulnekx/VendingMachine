using System.Collections.Generic;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Services
{
    public interface IProductService
    {
        IEnumerable<IProduct> FoodProducts { get; }

        IEnumerable<IProduct> SoftDrinkProducts { get; }

        void Import();
    }
}
