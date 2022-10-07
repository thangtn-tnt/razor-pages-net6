using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;

namespace RazorPages.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork db) => _db = db;

        public void OnGet(int id) => Category = _db.Category.GetFirstOrDefault(u => u.Id == id);

        public async Task<IActionResult> OnPost()
        {

            var categoryFromDb = _db.Category.GetFirstOrDefault((u => u.Id == Category.Id));
            if (categoryFromDb != null)
            {
                _db.Category.Remove(categoryFromDb);
                _db.Save();
                TempData["success"] = "Category was deleted successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
