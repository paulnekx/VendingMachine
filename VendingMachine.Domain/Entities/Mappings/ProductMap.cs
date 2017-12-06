using System.Collections.Generic;
using VendingMachine.Core.Interfaces;

namespace VendingMachine.Domain.Entities.Mappings
{
    public class ProductMap : IEntity, IEqualityComparer<ProductMap>
    {
        public int Id { get; set; }

        public decimal Cost { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var map = obj as ProductMap;
            return map != null &&
                   Id == map.Id;
        }

        public bool Equals(ProductMap x, ProductMap y)
        {
            return x.Equals(y);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public int GetHashCode(ProductMap obj)
        {
            return obj.GetHashCode();
        }

        public static bool operator ==(ProductMap map1, ProductMap map2)
        {
            return EqualityComparer<ProductMap>.Default.Equals(map1, map2);
        }

        public static bool operator !=(ProductMap map1, ProductMap map2)
        {
            return !(map1 == map2);
        }
    }
}
