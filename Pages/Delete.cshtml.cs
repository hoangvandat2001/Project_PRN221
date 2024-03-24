using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Logics;

namespace Project_PRN221.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ID { get; set; } = null!;
        public IActionResult OnGet()
        {
            var listClass = FileHandler.ReadFile();
            var classToDelete = listClass.FirstOrDefault(c => c.ID == ID);

            if (classToDelete != null)
            {
                listClass.Remove(classToDelete);
                FileHandler.UpdateFile(listClass);
            }

            return RedirectToPage("/Index");
        }
    }
}
