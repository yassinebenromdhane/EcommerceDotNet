using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTest.Models;

namespace WebAppTest.Pages
{
    public class StaffModel : PageModel
    {

        private readonly DemoContext? demoContext;
        public StaffModel(DemoContext? demoContext)
        {
            this.demoContext = demoContext;
        }
        public List<Staff> Staffs { get; set; }
        public void OnGet()
        {
            Staffs = demoContext.Staffs
                .Include(s => s.Manager)
                .Include(s => s.InverseManager)
                .ToList();
        }
    }
}
