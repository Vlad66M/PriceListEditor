using PriceListEditor.Models;

namespace PriceListEditor.ViewModels
{
    public class CreateProductVM
    {
        public int PriceListId {  get; set; }
        public string Name {  get; set; }
        public int Code {  get; set; }
        public List<ProductFeature> Features { get; set; }
    }
}
