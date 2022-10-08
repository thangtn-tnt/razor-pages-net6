using Microsoft.AspNetCore.Mvc;
using RazorPages.DataAccess.Repository.IRepository;

namespace RazorPages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _db;
        public MenuItemController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Get()
        {
            var menuItemList = _db.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new { data = menuItemList });
        }
    }
}
