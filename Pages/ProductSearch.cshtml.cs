using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTest.Models;

namespace WebAppTest.Pages
{
    public class ProductSearchModel(DemoContext? demoContext) : PageModel
    {
        private readonly DemoContext? demoContext = demoContext;

        public Product Product { get; set; }

        public void OnPost()
        {
            string pId = Request.Form["ProductId"];
            int productId = int.Parse(pId);
            Console.WriteLine(productId);
            Product = demoContext.Products
                .Where(p => p.ProductId == productId)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Stocks)
                .Include(p => p.OrderItems)
                .FirstOrDefault();
                

        }
    }
}
