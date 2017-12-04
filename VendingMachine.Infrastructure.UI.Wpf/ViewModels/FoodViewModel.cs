using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Entities;
using VendingMachine.Infrastructure.UI.Wpf.Models;

namespace VendingMachine.Infrastructure.UI.Wpf.ViewModels
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        private readonly FoodModel model = new FoodModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products { get; set; }

        public Product CurrentProduct { get; set; }

        public ObservableCollection<Product> Ingredients { get; set; }

        public Product CurrentIngredient { get; set; }

        public FoodViewModel()
        {
            Products = new ObservableCollection<Product>(model.GetFood());
            CurrentProduct = Products.FirstOrDefault();
            Ingredients = new ObservableCollection<Product>(model.GetIngredients());
            CurrentIngredient = Ingredients.FirstOrDefault();
        }
    }
}
