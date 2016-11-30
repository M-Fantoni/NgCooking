using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgData.Models
{
    public class User
    {
        public User()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string firstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public int Level { get; set; }
        public string City { get; set; }
        public string Birth { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
