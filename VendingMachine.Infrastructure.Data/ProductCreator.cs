using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.ExtensionMethods;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Data
{
    public class ProductCreator
    {
        private static readonly ProductCreator instance = new ProductCreator();

        public ProductFactory ProductFactory { get; private set; }

        private ProductCreator()
        {
            var productTypes = GetProductTypes();
            InitializeProductFactory(productTypes);
        }

        private IEnumerable<System.Type> GetProductTypes()
        {
            var type = typeof(Product);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);
            return types;
        }

        private void InitializeProductFactory(IEnumerable<System.Type> productTypes)
        {
            var container = new Container();
            ProductFactory = new ProductFactory(container);
            foreach (var type in productTypes)
            {
                var productName = type.GetDisplayName();
                if (!string.IsNullOrEmpty(productName))
                {
                    ProductFactory.Register(type, productName);
                }
            }
        }

        public static ProductCreator GetInstance()
        {
            return instance;
        }
    }
}
