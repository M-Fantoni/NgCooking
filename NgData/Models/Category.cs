using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgData.Models
{
    public class Category
    {
        public Category()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        public string Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

    }
}
