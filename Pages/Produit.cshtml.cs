using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTest.Models;

namespace WebAppTest.Pages
{
    public class ProduitModel : PageModel
    {
        private readonly DemoContext? demoContext;
        public ProduitModel(DemoContext? demoContext)
        {
            this.demoContext = demoContext;
        }
        public List<Product> Products { get; set; }
        public List<Store> Stores { get; set; }
        public void OnGet()
        {
            Products = demoContext.Products
                .Include( p => p.Category)
                .Include( p => p.Brand)
                .Include(p=>p.Stocks)
                .Include(p => p.OrderItems)
                .ThenInclude(oi => oi.Order)
                .ThenInclude(o => o.Store)
                .ToList();

             Stores = demoContext.Stores
                .ToList();

        }
    }
}
