using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Logics;

namespace Project_PRN221.Pages
{
    public class UpdateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ID { get; set; } = null!;
        [BindProperty(SupportsGet = true)]
        public string Room { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TimeSlot { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Class { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Subject { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Teacher { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var classes = FileHandler.ReadFile();
            var model = classes.Where(x=>x.ID == ID).FirstOrDefault();
            if (model != null)
            {
                model.Teacher = Teacher;
                model.Class = Class;
                model.Subject = Subject;
                model.TimeSlot = TimeSlot;
                model.Room = Room;
            }
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
                FileHandler.UpdateFile(classes);
            }
            return RedirectToPage("/Index");
        }
    }
}
