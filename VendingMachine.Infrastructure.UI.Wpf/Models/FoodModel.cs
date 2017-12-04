using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces;
using VendingMachine.Infrastructure.Data;

namespace VendingMachine.Infrastructure.UI.Wpf.Models
{
    internal class FoodModel
    {
        protected IProductRepository _repository = new ProductRepository();

        private IEnumerable<Product> _products;

        public FoodModel()
        {
            var products = _repository.Get();
            throw new NotImplementedException("абстрактная фабрика по вытаскиванию ЕДЫ");
            _products = products;
        }

        public IEnumerable<Product> GetFood()
        {
            throw new NotImplementedException("абстрактная фабрика по вытаскиванию ЕДЫ");
            return _products;
        }

        public IEnumerable<Product> GetIngredients()
        {
            throw new NotImplementedException("абстрактная фабрика по вытаскиванию ЕДЫ");
            return _products;
        }
    }
}
