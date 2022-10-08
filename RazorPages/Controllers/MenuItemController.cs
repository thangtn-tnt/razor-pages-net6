using Microsoft.AspNetCore.Mvc;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;

namespace RazorPages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuItemController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Get()
        {
            var menuItemList = _db.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new { data = menuItemList });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemFromDb = _db.MenuItem.GetFirstOrDefault(u => u.Id == id);

            //delete the old image
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, itemFromDb.Image.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _db.MenuItem.Remove(itemFromDb);
            _db.Save();

            return Json(new { success = true, message = "Delete successful!" });
        }
    }
}
