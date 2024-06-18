using PriceListEditor.Models;
using PriceListEditor.Pagination;

namespace PriceListEditor.ViewModels
{
    public class PriceListDetails
    {
        public PriceList PriceList { get; set; }
        public PagedList<Product> Products { get; set; } = new();
    }
}
