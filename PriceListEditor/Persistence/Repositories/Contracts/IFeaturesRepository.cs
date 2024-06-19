using PriceListEditor.Models;

namespace PriceListEditor.Persistence.Repositories.Contracts
{
    public interface IFeaturesRepository
    {
        Task<List<Feature>> GetAll();

        Task<List<Feature>> GetSelected(IEnumerable<int?> ids);

        Task<List<Feature>> GetByPriceListId(int id);
        Task<List<Feature>> GetByProductId(int id);
    }
}