using PriceListEditor.Enums;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor.ViewModels
{
    public class FeatureVM
    {
        public int? FeatureId {  get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
