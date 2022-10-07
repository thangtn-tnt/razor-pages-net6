using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;

namespace RazorPages.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public FoodType FoodType { get; set; }

        public EditModel(IUnitOfWork db) => _db = db;

        public void OnGet(int id) => FoodType = _db.FoodType.GetFirstOrDefault(u => u.Id == id);
        public async Task<IActionResult> OnPost(FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                _db.FoodType.Update(foodType);
                _db.Save();
                TempData["success"] = "Food type was edited successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
