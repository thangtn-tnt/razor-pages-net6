using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;
using System.Dynamic;

namespace RazorPages.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            MenuItem = new();
        }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                MenuItem = _db.MenuItem.GetFirstOrDefault(u => u.Id == id);
            }
            CategoryList = _db.Category.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            FoodTypeList = _db.FoodType.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (MenuItem.Id == 0)
            {
                //create
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                MenuItem.Image = @"\images\menuItems\" + fileName_new + extension;
                _db.MenuItem.Add(MenuItem);
                _db.Save();
            }
            else
            {
                //update
            }
            return RedirectToPage("./Index");
        }
    }
}
