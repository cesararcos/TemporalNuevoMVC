namespace TemporalNuevoMVC.Models
{
    public class ProductsViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public int ShippingCost { get; set; }
        public int Sold { get; set; }
        public string? Details { get; set; }
        public string? State { get; set; }
        public IEnumerable<string>? ImagesCollection { get; set; }

    }
}
