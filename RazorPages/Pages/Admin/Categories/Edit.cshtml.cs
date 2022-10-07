using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;

namespace RazorPages.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public Category Category { get; set; }

        public EditModel(IUnitOfWork db) => _db = db;

        public void OnGet(int id) => Category = _db.Category.GetFirstOrDefault(u => u.Id == id);

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                _db.Save();
                TempData["success"] = "Category was edited successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
