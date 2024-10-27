using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using TemporalNuevoMVC.DataAccess;
using TemporalNuevoMVC.Domain.Entities;
using TemporalNuevoMVC.Models;

namespace TemporalNuevoMVC.Controllers
{
    public class HomeController(ILogger<HomeController> logger, DataContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly DataContext Context = context;

        public IActionResult Index(string? name)
        {
            IEnumerable<Products> data = Context.Products;

            List<ProductsViewModel> products = data.Select(x => new ProductsViewModel()
            {
                Id = x.Id,
                Name = x.Name ?? string.Empty,
                Image = x.Image ?? string.Empty,
                State = x.State ?? string.Empty,
                Price = x.Price ?? 0,
                ShippingCost = x.ShippingCost ?? 0,
                Sold = x.Sold ?? 0,
                Details = x.Details ?? string.Empty
            }).ToList();

            if (!string.IsNullOrEmpty(name))
            {
                name = name.Trim().Replace(" ", string.Empty).ToUpper();
                products = products.Where(x => new { FullName = x.Name.Replace(" ", string.Empty).ToUpper() }.FullName.Contains(name)).Take(3).ToList();
            }

            return View(products);
        }

        public IActionResult Cart(int id)
        {
            IEnumerable<ImagesProducts> data = Context.ImagesProducts.Include(include => include.ProductsNavigation).Where(x => x.Products.Equals(id));

            List<ProductsViewModel> products = data.Select(x => new ProductsViewModel()
            {
                Id = x.ProductsNavigation.Id,
                Name = x.ProductsNavigation.Name ?? string.Empty,
                Image = x.Path ?? string.Empty,
                State = x.ProductsNavigation.State ?? string.Empty,
                Price = x.ProductsNavigation.Price ?? 0,
                ShippingCost = x.ProductsNavigation.ShippingCost ?? 0,
                Sold = x.ProductsNavigation.Sold ?? 0,
                Details = x.ProductsNavigation.Details ?? string.Empty,
            }).ToList();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
