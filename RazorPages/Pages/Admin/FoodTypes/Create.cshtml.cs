using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;

namespace RazorPages.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public FoodType FoodType { get; set; }

        public CreateModel(IUnitOfWork db) => _db = db;
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.FoodType.Add(FoodType);
                _db.Save();
                TempData["success"] = "Food type was created successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
