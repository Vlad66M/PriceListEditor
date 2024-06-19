using PriceListEditor.Models;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor.ViewModels
{
    public class CreateProductVM
    {
        public int PriceListId {  get; set; }

        [Required]
        public string Name {  get; set; }

        [Required]
        public int? Code {  get; set; }
        public List<ProductFeature>? Features { get; set; }
    }
}
