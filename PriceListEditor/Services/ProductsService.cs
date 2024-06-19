using PriceListEditor.Models;
using PriceListEditor.Persistence.Repositories.Contracts;
using PriceListEditor.Services.Contracts;
using PriceListEditor.ViewModels;

namespace PriceListEditor.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task CreateProduct(CreateProductVM createProductVM)
        {
            Product product = new Product();
            product.PriceListId = createProductVM.PriceListId;
            product.Name = createProductVM.Name;
            product.Code = createProductVM.Code;
            foreach (ProductFeature feature in createProductVM.Features)
            {
                feature.Product = product;
                
                product.ProductFeatures.Add(feature);
            }
            await _productsRepository.CreateProduct(product);
        }
    }
}
