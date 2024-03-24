using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Logics;
using Project_PRN221.Model;

namespace Project_PRN221.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Project_PRN221Context _context;

        public CreateModel(Project_PRN221Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassModel ClassModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var classes = FileHandler.ReadFile();
            var model = ClassModel;
            model.ID = Guid.NewGuid().ToString();
            var isValid = true;

            foreach (var item in classes)
            {
                if (model.TimeSlot == item.TimeSlot && model.Room == item.Room && item.Class != model.Class)
                {
                    isValid = false;
                    continue;
                }
                if (model.TimeSlot == item.TimeSlot && model.Teacher == item.Teacher && item.Class != model.Class)
                {
                    isValid = false;
                    continue;
                }
                if (model.Class == item.Class && model.TimeSlot == item.TimeSlot && item.Subject != model.Subject)
                {
                    isValid = false;
                    continue;
                }
            }
            if (isValid)
            {
                classes.Add(model);
            }
            FileHandler.UpdateFile(classes);
            return RedirectToPage("./Index");
        }
    }
}
