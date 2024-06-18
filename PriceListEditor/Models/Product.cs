namespace PriceListEditor.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public int PriceListId {  get; set; }
        public PriceList PriceList { get; set; }

        public List<ProductFeature> ProductFeatures { get; set; } = new();
    }
}
