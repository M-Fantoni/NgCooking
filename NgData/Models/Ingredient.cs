using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgData.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int Calories { get; set; }
        public string Picture { get; set; }

        public string CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }


    }
}
