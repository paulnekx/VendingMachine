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
        public int Quantity { get; set; } = 1;

        public decimal Cost { get; set; }

        public ReadOnlyCollection<IIngredient> BasicIngredients { get; set; } = new List<IIngredient>().AsReadOnly();

        public List<IIngredient> OptionalIngredients { get; set; } = new List<IIngredient>();

        public ReadOnlyCollection<IIngredient> Ingredients
        {
            get
            {
                var ingredients = BasicIngredients.Union(OptionalIngredients).ToList();
                return new ReadOnlyCollection<IIngredient>(ingredients);
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
