using PriceListEditor.Models;

namespace PriceListEditor.Persistence.Repositories.Contracts
{
    public interface IProductsRepository
    {
        Task CreateProduct(Product product);
    }
}
