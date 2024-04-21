using System;
using System.Collections.Generic;

namespace TemporalNuevoMVC.Domain.Entities
{
    public partial class Products
    {
        public Products()
        {
            ImagesProducts = new HashSet<ImagesProducts>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? Price { get; set; }
        public int? ShippingCost { get; set; }
        public int? Sold { get; set; }
        public string? Details { get; set; }
        public string? State { get; set; }

        public virtual ICollection<ImagesProducts> ImagesProducts { get; set; }
    }
}
