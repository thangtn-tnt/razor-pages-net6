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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _db;

        public CategoryRepository(ApplicationDBContext _context) : base(_context) => _db = _context;

        public void Save() => _db.SaveChanges();

        public void Update(Category category)
        {
            var categoryFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
            categoryFromDb.Name = category.Name;
            categoryFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
