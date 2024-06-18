using PriceListEditor.Models;
using PriceListEditor.Pagination;
using PriceListEditor.ViewModels;

namespace PriceListEditor.Persistence.Repositories.Contracts
{
    public interface IPriceListsRepository
    {
        Task Create(PriceList priceList);
        Task Delete(int id);
        Task<PagedList<PriceList>> GetAll(int? page);
        Task<PriceListDetails> GetDetails(int id, int? page);
    }
}
