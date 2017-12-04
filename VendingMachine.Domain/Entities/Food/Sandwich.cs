using System.Collections.Generic;
using System.ComponentModel;
using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Entities.Food
{
    [DisplayName("Бутерброд")]
    public class Sandwich : Product, IFood
    {
        public Sandwich(BreadProduct breadProduct) : base(new List<BreadProduct> { breadProduct })
        {
            Cost = breadProduct.Cost;
        }
    }
}