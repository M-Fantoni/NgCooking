using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NgData.Models;

namespace NgCooking.Models
{
    public class HomeModel
    {
        public List<BestRecipe> BestRecipes { get; set; }
        public List<Recipe> NewRecipes { get; set; }
    }

    public class BestRecipe
    {
        public Recipe Recipe { get; set; }
        public Decimal AverageMark { get; set; }
    }
}