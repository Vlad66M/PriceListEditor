using PriceListEditor.Models;

namespace PriceListEditor.Persistence.Repositories.Contracts
{
    public interface IFeaturesRepository
    {
        Task<List<Feature>> GetAll();
    }
}