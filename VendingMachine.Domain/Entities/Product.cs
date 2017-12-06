using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using VendingMachine.Core.ExtensionMethods;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities
{
    public class Product : IProduct
    {
        public int Id { get; set; }

        public int Quantity { get; set; } = 1;

        public decimal Cost { get; set; }

        public ReadOnlyCollection<IProduct> BasicIngredients { get; set; } = new List<IProduct>().AsReadOnly();

        public List<IProduct> OptionalIngredients { get; set; } = new List<IProduct>();

        public ReadOnlyCollection<IProduct> Ingredients
        {
            get
            {
                var ingredients = BasicIngredients.Union(OptionalIngredients).ToList();
                return new ReadOnlyCollection<IProduct>(ingredients);
            }
        }

        public override string ToString()
        {
            var productName = GetType().GetDisplayName() ?? GetType().Name;
            var stringBuilder = new StringBuilder(productName);

            if (!Ingredients.IsNullOrEmpty())
            {
                var ingredients = Ingredients.Select(l => l.ToString()).ToList();
                stringBuilder.Append($"({string.Join("+", ingredients)})");
            }
            return stringBuilder.ToString();
        }
    }
}
