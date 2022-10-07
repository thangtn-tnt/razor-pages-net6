using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;

namespace RazorPages.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public FoodType FoodType { get; set; }

        public DeleteModel(IUnitOfWork db) => _db = db;

        public void OnGet(int id) => FoodType = _db.FoodType.GetFirstOrDefault(u => u.Id == id);
        public async Task<IActionResult> OnPost()
        {

            var foodTypeFromDb = _db.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
            if (foodTypeFromDb != null)
            {
                _db.FoodType.Remove(foodTypeFromDb);
                _db.Save();
                TempData["success"] = "Food type was deleted successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
