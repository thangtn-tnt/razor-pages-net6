using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public MenuItem MenuItem { get; set; }

        public UpsertModel(IUnitOfWork db) => _db = db;

        public void OnGet()
        {
            MenuItem = new();
        }
    }
}
