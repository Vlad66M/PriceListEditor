using Microsoft.EntityFrameworkCore;
using PriceListEditor.Models;
using PriceListEditor.Persistence.DbContexts;
using PriceListEditor.Persistence.Repositories.Contracts;

namespace PriceListEditor.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {

        public async Task<Product> GetById(int id)
        {
            using (DbContextSqlite db = new())
            {
                var product = await db.Products
                    .Include(p=>p.ProductFeatures)
                    .Select(p=>new Product()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Code = p.Code,
                        PriceList = p.PriceList,
                        PriceListId = p.PriceListId,
                        ProductFeatures = p.ProductFeatures.OrderBy(f=>f.Id).ToList()
                    })
                    .FirstAsync(x => x.Id == id);
                return product;
            }
        }
        public async Task Create(Product product)
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

        public async Task Delete(int id)
        {
            using (DbContextSqlite db = new())
            {
                var product = await db.Products.Where(x => x.Id == id).FirstAsync();
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
        }
    }
}
