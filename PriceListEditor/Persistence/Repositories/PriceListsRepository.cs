using Microsoft.EntityFrameworkCore;
using PriceListEditor.Models;
using PriceListEditor.Pagination;
using PriceListEditor.Persistence.DbContexts;
using PriceListEditor.Persistence.Repositories.Contracts;
using PriceListEditor.ViewModels;
using System;

namespace PriceListEditor.Persistence.Repositories
{
    /*class ProductsComparer : IComparer<Product>
    {
        public int Compare(Product? p1, Product? p2)
        {
            var feature1 = p1.ProductFeatures.FirstOrDefault(f => f.F)
        }
    }*/
    public class PriceListsRepository : IPriceListsRepository
    {
        private const int pageSize = 5;
        public async Task<PagedList<PriceList>> GetAll(int? page)
        {
            using (DbContextSqlite db = new())
            {
                var priceLists = db.PriceLists.OrderBy(x => x.Id).AsQueryable();
                return await PagedList<PriceList>.ToPagedList(priceLists, page, pageSize);
            }
        }

        public async Task<PriceListDetails> GetDetails(int id, int? page = null, int? orderby = null, bool? asc = null)
        {
            using (DbContextSqlite db = new())
            {
                PriceList priceList = await db.PriceLists.Include(x => x.Features).FirstAsync(x => x.Id == id);

                var products = db.Products.Where(x => x.PriceListId == id).Include(x => x.ProductFeatures).OrderBy(x => x.Id);

                if(orderby is not null)
                {
                    if(orderby == 1)
                    {
                        if(asc == true)
                        {
                            products = products.OrderBy(x => x.Name);
                        }
                        if (asc == false)
                        {
                            products = products.OrderByDescending(x => x.Name);
                        }
                    }
                    if (orderby == 2)
                    {
                        if (asc == true)
                        {
                            products = products.OrderBy(x => x.Code);
                        }
                        if (asc == false)
                        {
                            products = products.OrderByDescending(x => x.Code);
                        }
                    }
                    if (orderby > 2)
                    {
                        if (asc == true)
                        {
                            products = products.OrderBy(x => x.ProductFeatures.FirstOrDefault(f => f.FeatureId == orderby).Value ?? "");
                        }
                        if (asc == false)
                        {
                            products = products.OrderByDescending(x => x.ProductFeatures.FirstOrDefault(f => f.FeatureId == orderby).Value ?? "");
                        }
                    }
                }

                PriceListDetails details = new();

                details.PriceList = priceList;

                details.Products = await PagedList<Product>.ToPagedList(products, page, pageSize);

                return details;
            }
        }

        public async Task Create(PriceList priceList)
        {
            using (DbContextSqlite db = new())
            {
                db.PriceLists.Add(priceList);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (DbContextSqlite db = new())
            {
                var priceList = await db.PriceLists.FirstOrDefaultAsync(x => x.Id == id);
                if (priceList is not null)
                {
                    db.PriceLists.Remove(priceList);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
