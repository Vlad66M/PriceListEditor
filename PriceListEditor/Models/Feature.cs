using PriceListEditor.Enums;

namespace PriceListEditor.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public FeatureType Type { get; set; }

        public List<PriceList> PriceLists { get; set; } = new();
    }
}
