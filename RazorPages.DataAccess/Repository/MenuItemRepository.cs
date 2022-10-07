using Microsoft.EntityFrameworkCore;
using RazorPages.DataAccess.Data;
using RazorPages.DataAccess.Repository.IRepository;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDBContext _db;

        public MenuItemRepository(ApplicationDBContext _context) : base(_context) => _db = _context;

        public void Save() => _db.SaveChanges();

        public void Update(MenuItem menuItem)
        {
            var itemFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == menuItem.Id);
            itemFromDb.Name = menuItem.Name;
            itemFromDb.Description = menuItem.Description;
            itemFromDb.Price = menuItem.Price;
            itemFromDb.CategoryId = menuItem.CategoryId;
            itemFromDb.FoodTypeId = menuItem.FoodTypeId;
            if (itemFromDb.Image != null)
            {
                itemFromDb.Image = menuItem.Image;
            }
        }
    }
}
