using PriceListEditor.ViewModels;

namespace PriceListEditor.Services.Contracts
{
    public interface IProductsService
    {
        Task CreateProduct(CreateProductVM createProductVM);
    }
}
