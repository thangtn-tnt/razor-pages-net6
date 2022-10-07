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
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDBContext _db;

        public FoodTypeRepository(ApplicationDBContext _context) : base(_context) => _db = _context;

        public void Save() => _db.SaveChanges();

        public void Update(FoodType foodType)
        {
            var itemFromDb = _db.FoodType.FirstOrDefault(u => u.Id == foodType.Id);
            itemFromDb.Name = foodType.Name;
        }
    }
}
