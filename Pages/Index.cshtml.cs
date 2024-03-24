using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_PRN221.Logics;
using Project_PRN221.Model;

namespace Project_PRN221.Pages
{
    public class IndexModel : PageModel
    {      
        private readonly Project_PRN221Context _context;
        public List<ClassModel> listClass { get; set; } = new List<ClassModel>();
        public IndexModel(Project_PRN221Context context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //FileHandler.SaveFile(_context.Classes.Include(x => x.Timeslot).Include(x => x.Subject).Include(x => x.Teacher).Include(x => x.Room)
            //    .ToList());
            //listClass = FileHandler.ReadFile();
        }
        public void OnPost(string file)
        {
            listClass = FileHandler.ReadFile();
        }
        public  IActionResult OnPostDelete(string id)
        {
            var classToDelete =  listClass.FirstOrDefault(c => c.ID == id);

            if (classToDelete != null)
            {
                listClass.Remove(classToDelete);
                FileHandler.UpdateFile(listClass);
            }

            return RedirectToPage("/Index");
        }
    }
}
