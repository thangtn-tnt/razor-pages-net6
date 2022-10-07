﻿using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.DataAccess.Repository.IRepository
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        void Update(FoodType foodType);
    }
}
