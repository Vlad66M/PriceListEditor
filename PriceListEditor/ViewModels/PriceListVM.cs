using System.ComponentModel.DataAnnotations;

namespace PriceListEditor.ViewModels
{
    public class PriceListVM
    {
        [Required]
        public string Name {  get; set; }
        public FeatureVM[]? Features { get; set; }
    }
}
