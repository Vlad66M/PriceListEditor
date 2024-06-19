using PriceListEditor.Models;
using PriceListEditor.Persistence.DbContexts;
using PriceListEditor.Persistence.Repositories.Contracts;

namespace PriceListEditor.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public async Task CreateProduct(Product product)
        {
            using (DbContextSqlite db = new())
            {
                db.Products.Add(product);
                foreach (ProductFeature feature in product.ProductFeatures)
                {
                    db.ProductFeatures.Add(feature);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
