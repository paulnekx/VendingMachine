using VendingMachine.Core.Interfaces;

namespace VendingMachine.Domain.Entities.Mappings
{
    public class RecipeMap : IEntity
    {
        public int Id { get; set; }

        public ProductMap Product { get; set; }

        public ProductMap Ingredient { get; set; }

        public bool IsOptional { get; set; }
    }
}
