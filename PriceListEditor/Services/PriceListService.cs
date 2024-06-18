using PriceListEditor.Enums;
using PriceListEditor.Models;
using PriceListEditor.Persistence.Repositories.Contracts;
using PriceListEditor.Services.Contracts;
using PriceListEditor.ViewModels;

namespace PriceListEditor.Services
{
    public class PriceListService : IPriceListService
    {
        private readonly IPriceListsRepository _priceListsRepository;
        private readonly IFeaturesRepository _featuresRepository;

        public PriceListService(IPriceListsRepository priceListsRepository,
                                IFeaturesRepository featuresRepository)
        {
            _priceListsRepository = priceListsRepository;
            _featuresRepository = featuresRepository;
        }

        public async Task CreatePriceList(PriceListVM priceListVM)
        {
            PriceList priceList = new PriceList();
            priceList.Name = priceListVM.Name;
            foreach (FeatureVM featureVM in priceListVM.Features)
            {
                Feature feature = new Feature();
                feature.Title = featureVM.Title;
                feature.Type = SelectFeatureType(featureVM.Type);
                priceList.Features.Add(feature);
            }
            await _priceListsRepository.Create(priceList);

        }

        private FeatureType SelectFeatureType(string featureType)
        {
            switch (featureType)
            {
                case "number":
                    {
                        return FeatureType.Number;
                    }
                case "line":
                    {
                        return FeatureType.Line;
                    }
                case "multiline":
                    {
                        return FeatureType.Multiline;
                    }
                default:
                    {
                        throw new Exception("Unknown feature type: " + featureType);
                    }
            }
        }

        /*public async Task<PriceListDetails> GetDetails(int id, int? page)
        {
            return await _priceListsRepository.GetDetails(id, page);
        }*/
    }
}
