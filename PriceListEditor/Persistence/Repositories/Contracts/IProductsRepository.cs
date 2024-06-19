using PriceListEditor.Models;

namespace PriceListEditor.Persistence.Repositories.Contracts
{
    public interface IProductsRepository
    {
        Task<Product> GetById(int id);
        Task Create(Product product);
        Task Delete(int id);
    }
}
