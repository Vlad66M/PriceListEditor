namespace PriceListEditor.Models
{
    public class PriceList
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public List<Feature> Features { get; set; } = new();
    }
}
