namespace PriceListEditor.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }
        public string Value {  get; set; }
    }
}
