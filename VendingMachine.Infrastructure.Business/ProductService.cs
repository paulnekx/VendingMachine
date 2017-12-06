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
using AutoMapper;

namespace VendingMachine.Infrastructure.Business
{
    public class ProductService : IProductService, IDisposable
    {
        private bool disposedValue = false;
        private IEqualityComparer<ProductMap> _comparer;
        private static IProductFactory _productFactory;
        private readonly IProductRepository _productRepository;
        private readonly IRecipeRepository _recipeRepository;

        //public ReadOnlyCollection<IProduct> Products { get; private set; }

        public Menu Menu { get; private set; } = new Menu();

        public IEnumerable<IProduct> FoodProducts { get; private set; }

        public IEnumerable<IProduct> SoftDrinkProducts { get; private set; }

        static ProductService()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<ProductMap, IProduct>()
                //.BeforeMap((src, dest) =>
                //{
                //    dest = _productFactory.Create(src.Name);
                //});
                cfg.CreateMap<KeyValuePair<ProductMap, IEnumerable<RecipeMap>>, IProduct>()
                .BeforeMap((src, dest) =>
                {
                    dest = _productFactory.Create(src.Key.Name);
                })
                .AfterMap((src, dest) =>
                {
                    var basicIngredients = src.Value
                        .Where(l => !l.IsOptional)
                        .Select(l => _productFactory.Create(l.Ingredient.Name))
                        .ToList();
                    dest.BasicIngredients = new ReadOnlyCollection<IProduct>(basicIngredients);
                });
            });
        }

        /// <summary>
        /// С введением IoC данный конструктор потеряет актуальность
        /// </summary>
        public ProductService() : this(new ProductRepository(), new RecipeRepository(), new ProductMap())
        {

        }

        public ProductService(IProductRepository productRepository, IRecipeRepository recipeRepository, IEqualityComparer<ProductMap> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            _productFactory = ProductCreator.GetInstance().ProductFactory;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        public void Import()
        {
            var t = _productRepository.Get().GroupJoin(_recipeRepository.Get(),
                o => o, i => i.Product,
                (o, i) =>  new
                {
                    Product = o,
                    Ingredients = i.Select(l => l.Ingredient)


                    //var product = Mapper.Map<KeyValuePair<ProductMap, IEnumerable<RecipeMap>>, IProduct>(new KeyValuePair<ProductMap, IEnumerable<RecipeMap>>(o, i));


                    //var test = i.Where(l => l.IsOptional).Select(l => Mapper.Map<IProduct>())

                    ////var optionalIngredients = src.Value
                    ////    
                    ////    .Select(l => _productFactory.Create(l.Ingredient.Name))
                    ////    .ToList();
                    ////dest.OptionalIngredients = optionalIngredients;

                    //return new KeyValuePair<IProduct, IEnumerable<IProduct>>(product, )
                },
                _comparer);

            var products = new List<Product>();
            foreach (var item in mapProductToIngredients)
            {
                var product = _productFactory.Create(item.Key.Name);
                Mapper.Map(source: item, destination: product);
            }

            var products1 = mapProductToIngredients.Select(l =>
           {
               var product = _productFactory.Create(l.Key.Name);
               Mapper.Map(source: l, destination: product);
               return product;
           });
            //Products = 
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
