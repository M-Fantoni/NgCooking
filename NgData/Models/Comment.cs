using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgData.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RecipeId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Decimal Mark { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipes { get; set; }
    }
}
