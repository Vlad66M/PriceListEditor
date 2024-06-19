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

        public async Task<List<Feature>> GetByPriceListId(int id)
        {
            using (DbContextSqlite db = new())
            {
                var features = await db.PriceLists.Where(x => x.Id == id).Select(x => x.Features).FirstAsync();
                return features;
            }
        }
    }
}
