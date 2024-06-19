using Microsoft.EntityFrameworkCore;
using PriceListEditor.Models;
using PriceListEditor.Persistence.DbContexts;
using PriceListEditor.Persistence.Repositories.Contracts;

namespace PriceListEditor.Persistence.Repositories
{
    public class FeaturesRepository : IFeaturesRepository
    {
        public async Task<List<Feature>> GetAll()
        {
            using (DbContextSqlite db = new())
            {
                var features = await db.Features.ToListAsync();
                return features;
            }
        }

        public async Task<List<Feature>> GetSelected(IEnumerable<int?> ids)
        {
            using (DbContextSqlite db = new())
            {
                var features = await db.Features.Where(f => ids.Contains(f.Id)).ToListAsync();
                return features;
            }
        }

        public async Task<List<Feature>> GetByPriceListId(int id)
        {
            using (DbContextSqlite db = new())
            {
                var features = await db.PriceLists.Where(x => x.Id == id).Select(x => x.Features).FirstOrDefaultAsync();
                if(features is null)
                {
                    return new List<Feature>();
                }
                return features;
            }
        }

        public async Task<List<Feature>> GetByProductId(int id)
        {
            List<Feature> features = new();
            using (DbContextSqlite db = new())
            {
                var product = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
                if(product is not null)
                {
                    var price = await db.PriceLists.FirstOrDefaultAsync(x => x.Id == product.PriceListId);
                    if(price is not null)
                    {
                        features = await db.PriceLists.Where(x => x.Id == price.Id).Select(x => x.Features).FirstAsync();
                    }
                }
                return features;

            }
        }

    }
}
