using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Entities.Interfaces;
using VendingMachine.Domain.Interfaces;
using VendingMachine.Infrastructure.Data;
using VendingMachine.Services;
using System.Linq;
using VendingMachine.Domain.Entities.Mappings;
using SimpleInjector;

namespace VendingMachine.Infrastructure.Business
{
    public class ProductService : IProductService, IDisposable
    {
        private IEqualityComparer<ProductMap> _comparer;
        private bool disposedValue = false;
        private readonly IProductRepository _productRepository;
        private readonly IRecipeRepository _recipeRepository;

        public ReadOnlyCollection<IProduct> Products { get; private set; }

        /// <summary>
        /// С введением IoC данный конструктор потеряет актуальность
        /// </summary>
        public ProductService() : this(new ProductRepository(), new RecipeRepository(), new ProductMap())
        {

        }

        public ProductService(IProductRepository productRepository, IRecipeRepository recipeRepository, IEqualityComparer<ProductMap> comparer)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            Initialize();
        }

        private void Initialize()
        {
            var products = _productRepository.Get();
            var recipes = _recipeRepository.Get();
            var productToIngredient = products.GroupJoin(recipes, o => o, i => i.Product, (o, i) => new
            {
                Product = o,
                Ingredients = i
            }, _comparer);

            RegisterProductFactory(out var productFactory);
            
            Products = productToIngredient.Select(l => 
            {
                var ingredients = l.Ingredients.Cast<IIngredient>();
                var product = productFactory.Create(l.Product.Name);
                product.BasicIngredients = new ReadOnlyCollection<IIngredient>(ingredients);
                return product;
            });
        }

        private void RegisterProductFactory(out ProductFactory productFactory)
        {
            var container = new Container();
            var factory = new ProductFactory(container);
            factory.Register<Bread>("Хлеб");
            factory.Register<Bun>("Булочка");
            factory.Register<Chips>("Чипсы");
            factory.Register<Cookie>("Печенье");
            factory.Register<Ham>("Ветчина");
            factory.Register<Cheese>("Сыр");
            factory.Register<Water>("Вода");
            factory.Register<Espresso>("Эспрессо");
            factory.Register<Latte>("Латте");
            factory.Register<Cappuccino>("Капучино");
            factory.Register<BlackTea>("Чай черный");
            factory.Register<GreenTea>("Чай зеленый");
            factory.Register<Milk>("Молоко");
            factory.Register<Sugar>("Сахар");
            container.RegisterSingleton<IProductFactory>(factory);
            productFactory = factory;
        }

        public IEnumerable<IProduct> GetFoodProducts()
        {
            return Products.Where(l => typeof(IFood).IsAssignableFrom(l.GetType()));
        }

        public IEnumerable<IProduct> GetSoftDrinkProducts()
        {
            return Products.Where(l => typeof(IDrink).IsAssignableFrom(l.GetType()));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _productRepository.Dispose();
                    _recipeRepository.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
