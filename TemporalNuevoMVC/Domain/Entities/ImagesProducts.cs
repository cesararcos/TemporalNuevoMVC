using System;
using System.Collections.Generic;

namespace TemporalNuevoMVC.Domain.Entities
{
    public partial class ImagesProducts
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int Products { get; set; }

        public virtual Products ProductsNavigation { get; set; } = null!;
    }
}
