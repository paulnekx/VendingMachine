using VendingMachine.Domain.Entities.Interfaces;

namespace VendingMachine.Domain.Interfaces
{
    public interface IProductFactory
    {
        IProduct Create(string productName);
    }
}
