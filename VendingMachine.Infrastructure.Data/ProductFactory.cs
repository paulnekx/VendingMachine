using SimpleInjector;
using System;
using System.Collections.Generic;
using VendingMachine.Domain.Entities.Interfaces;
using VendingMachine.Domain.Interfaces;

namespace VendingMachine.Infrastructure.Data
{
    public class ProductFactory : IProductFactory
    {
        private readonly Container container;
        private readonly Dictionary<string, InstanceProducer> producers = 
            new Dictionary<string, InstanceProducer>(StringComparer.OrdinalIgnoreCase);

        public ProductFactory(Container container)
        {
            this.container = container;
        }

        public IProduct Create(string name) => producers[name].GetInstance() as IProduct;

        //public void Register<TImplementation>(string name, Lifestyle lifestyle = null) where TImplementation : class, IProduct
        //{
        //    var producer = (lifestyle ?? container.Options.DefaultLifestyle)
        //        .CreateProducer<IProduct, TImplementation>(container);

        //    producers.Add(name, producer);
        //}

        public void Register(Type type, string name, Lifestyle lifestyle = null)
        {
            var producer = (lifestyle ?? container.Options.DefaultLifestyle)
                .CreateProducer(typeof(IProduct), type, container);

            producers.Add(name, producer);
        }
    }
}

