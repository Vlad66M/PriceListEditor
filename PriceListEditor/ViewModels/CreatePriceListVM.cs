using PriceListEditor.Models;

namespace PriceListEditor.ViewModels
{
    public class CreatePriceListVM
    {
        public List<Feature> ExistingFeatures { get; set; } = new();
        public PriceListVM PriceListVM { get; set; }

    }
}
