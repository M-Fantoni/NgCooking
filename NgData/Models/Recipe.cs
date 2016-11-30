using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgData.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.Comments = new HashSet<Comment>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsAvailable { get; set; }
        public string Picture { get; set; }
        public int Calories { get; set; }
        public string Preparation { get; set; }
        public DateTime? CreationDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
