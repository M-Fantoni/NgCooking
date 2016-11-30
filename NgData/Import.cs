using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgData
{
    class Import
    {
        //Juste a titre informatif, le code que j'ai utilisé pour importer le json dans la db
        public Import()
        {
            //using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\categories.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    var cat = serializer.Deserialize(file, typeof(List<JsonCategory>));

            //    foreach (var item in cat as List<JsonCategory>)
            //    {
            //        NgData.Models.Category category = new NgData.Models.Category { Id = item.id, Label = item.nameToDisplay };

            //        context.Categories.Add(category);
            //    }
            //    context.SaveChanges();
            //}

            //using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\communaute.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    var cat = serializer.Deserialize(file, typeof(List<JsonUser>));

            //    foreach (var item in cat as List<JsonUser>)
            //    {
            //        NgData.Models.User user = new NgData.Models.User
            //        {
            //            Bio = item.bio,
            //            Birth = item.birth.ToString(),
            //            City = item.city,
            //            Email = item.email,
            //            firstName = item.firstname,
            //            Id = item.id,
            //            LastName = item.surname,
            //            Level = item.level,
            //            Password = item.password,
            //            Picture = item.picture,

            //        };

            //        context.Users.Add(user);


            //    }
            //    context.SaveChanges();
            //}

            //using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\ingredients.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    var cat = serializer.Deserialize(file, typeof(List<JsonIngredients>));

            //    foreach (var item in cat as List<JsonIngredients>)
            //    {
            //        NgData.Models.Ingredient ingredient = new NgData.Models.Ingredient
            //        {
            //            Calories = item.calories,
            //            CategoryId = context.Categories.SingleOrDefault(m => m.Id == item.category).Id,
            //            Id = item.id,
            //            IsAvailable = item.isAvailable,
            //            Name = item.name,
            //            Picture = item.picture
            //        };

            //        context.Ingredients.Add(ingredient);


            //    }
            //    context.SaveChanges();
            //}

            //using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\recettes.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    var cat = serializer.Deserialize(file, typeof(List<JsonRecipes>));
            //    List<JsonRecipes> catList = new List<JsonRecipes>();
            //    catList.AddRange(cat as List<JsonRecipes>);


            //    List<NgData.Models.Recipe> recipes = new List<NgData.Models.Recipe>();


            //    //foreach (var item in cat as List<JsonRecipes>)
            //    for (int i = 0; i < catList.Count(); i++)
            //    {
            //        List<NgData.Models.Ingredient> ingredients = new List<NgData.Models.Ingredient>();
            //        List<NgData.Models.Comment> comments = new List<NgData.Models.Comment>();
            //        NgData.Models.Recipe recipe = new NgData.Models.Recipe();

            //        foreach (var ingr in catList[i].ingredients.ToList())
            //        {
            //            ingredients.Add(context.Ingredients.Where(m => m.Id == ingr).SingleOrDefault());
            //        }

            //        if (catList[i].comments != null)
            //        {
            //            foreach (var com in catList[i].comments.ToList())
            //            {
            //                comments.Add(new NgData.Models.Comment { Mark = com.mark, RecipeId = catList[i].id, Text = com.comment, Title = com.title, UserId = com.userId });
            //            }
            //        }

            //        recipe.Ingredients = ingredients;
            //        recipe.Comments = comments;
            //        recipe.Calories = catList[i].calories;
            //        recipe.Id = catList[i].id;
            //        recipe.IsAvailable = catList[i].isAvailable;
            //        recipe.Name = catList[i].name;
            //        recipe.Picture = catList[i].picture;
            //        recipe.Preparation = catList[i].preparation;
            //        recipe.UserId = catList[i].creatorId;

            //        recipes.Add(recipe);


            //    }

            //    context.Recipes.AddRange(recipes);
            //    context.SaveChanges();
            //}
        }
    }
}
