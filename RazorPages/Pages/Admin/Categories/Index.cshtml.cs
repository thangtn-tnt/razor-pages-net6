using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;

namespace RazorPages.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public IEnumerable<Category> Categories { get; set; }


        public IndexModel(IUnitOfWork db) => _db = db;

        public void OnGet() => Categories = _db.Category.GetAll();
    }
}
