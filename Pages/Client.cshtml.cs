using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTest.Models;

namespace WebAppTest.Pages
{
    
    public class ClientModel : PageModel
    {
        private readonly DemoContext? demoContext;



        public ClientModel(DemoContext? demoContext)
        {
            this.demoContext = demoContext;
        }


        public List<Customer> Customers { get; set; }
        public void OnGet()
        {
            Customers = demoContext.Customers.Include(c => c.Orders).ToList();
        }
    }
}
