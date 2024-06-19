using PriceListEditor.Models;

namespace PriceListEditor.ViewModels
{
    public class ProductDetailsVM
    {
        public List<Feature> Features = new List<Feature>();
        public Product Product { get; set; }
    }
}
