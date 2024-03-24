using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_PRN221.Model;

namespace Project_PRN221.Pages
{
    public class IndexModel : PageModel
    {      
        private readonly Project_PRN221Context _context;
        public List<Class> listClass { get; set; } = new List<Class>();
        public IndexModel(Project_PRN221Context context)
        {
            _context = context;
        }

        public void OnGet()
        {
            listClass = _context.Classes.Include(x => x.Timeslot).Include(x => x.Subject). Include(x => x.Teacher).Include(x => x.Room)
                .ToList();
        }
    }
}
