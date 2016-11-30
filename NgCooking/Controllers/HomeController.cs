using Newtonsoft.Json;
using NgCooking.Models;
using NgData;
using NgData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            //On vérifie si l'utilisateur est connecté
            ViewBag.IsConnected = Utils.ManageConnection.isConnected(this.ControllerContext, context);

            HomeModel model = new HomeModel();
            model.BestRecipes = new List<BestRecipe>();
            model.NewRecipes = new List<Recipe>();

            BestRecipes(model.BestRecipes);
            NewRecipes(model.NewRecipes);

            return View(model);
        }

        public ActionResult About()
        {
            //On vérifie si l'utilisateur est connecté
            ViewBag.IsConnected = Utils.ManageConnection.isConnected(this.ControllerContext, context);

            return View();
        }

        public ActionResult Contact()
        {
            //On vérifie si l'utilisateur est connecté
            ViewBag.IsConnected = Utils.ManageConnection.isConnected(this.ControllerContext, context);

            return View();
        }

        /// <summary>
        /// Récupère la liste des recettes les plus récentes, par defaut 4
        /// </summary>
        /// <param name="recipes"></param>
        /// <param name="howManyRecipes"></param>
        private void NewRecipes(List<Recipe> recipes, int howManyRecipes = 4)
        {
            recipes = context.Recipes.OrderByDescending(m => m.CreationDate).Take(howManyRecipes).ToList();
        }

        /// <summary>
        /// Récupère la liste des recettes ayant la meilleure moyenne, par defaut 4
        /// </summary>
        /// <param name="recipes"></param>
        /// <param name="howManyRecipes"></param>
        private void BestRecipes(List<BestRecipe> recipes, int howManyRecipes = 4)
        {
            //récupère une liste de recette trié par moyenne dont la taille dépend du paramètre howManyRecipes
            List<Recipe> bestAverageRecipe = context.Recipes.OrderByDescending(m => m.Comments.Average(z => z.Mark)).Take(howManyRecipes).ToList();

            //on créé la liste de BestRecipe
            foreach (var item in bestAverageRecipe)
            {
                if (item.Comments.Count > 0)
                {
                    recipes.Add(new BestRecipe
                    {
                        Recipe = item,
                        AverageMark = item.Comments.Average(m => m.Mark)
                    });
                }
                else
                {
                    recipes.Add(new BestRecipe { Recipe = item, AverageMark = 0 });
                }
            }
        }

        /// <summary>
        /// Ajoute les data des fichier json fournis dans la bdd.
        /// Cette méthode n'est vouée qu'a être utilisée qu'une seule fois, ou en cas de reset de la bd, elle n'est pas utilisée dans le projet lui même
        /// </summary>
        private void Seeding()
        {
            using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\categories.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var cat = serializer.Deserialize(file, typeof(List<JsonCategory>));

                foreach (var item in cat as List<JsonCategory>)
                {
                    NgData.Models.Category category = new NgData.Models.Category { Id = item.id, Label = item.nameToDisplay };

                    context.Categories.Add(category);
                }
                context.SaveChanges();
            }

            using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\communaute.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var cat = serializer.Deserialize(file, typeof(List<JsonUser>));

                foreach (var item in cat as List<JsonUser>)
                {
                    NgData.Models.User user = new NgData.Models.User
                    {
                        Bio = item.bio,
                        Birth = item.birth.ToString(),
                        City = item.city,
                        Email = item.email,
                        firstName = item.firstname,
                        Id = item.id,
                        LastName = item.surname,
                        Level = item.level,
                        Password = item.password,
                        Picture = item.picture,

                    };

                    context.Users.Add(user);


                }
                context.SaveChanges();
            }

            using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\ingredients.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var cat = serializer.Deserialize(file, typeof(List<JsonIngredients>));

                foreach (var item in cat as List<JsonIngredients>)
                {
                    NgData.Models.Ingredient ingredient = new NgData.Models.Ingredient
                    {
                        Calories = item.calories,
                        CategoryId = context.Categories.SingleOrDefault(m => m.Id == item.category).Id,
                        Id = item.id,
                        IsAvailable = item.isAvailable,
                        Name = item.name,
                        Picture = item.picture
                    };

                    context.Ingredients.Add(ingredient);


                }
                context.SaveChanges();
            }

            using (StreamReader file = System.IO.File.OpenText(@"D:\matthieu\ngCooking-master\json\recettes.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var cat = serializer.Deserialize(file, typeof(List<JsonRecipes>));
                List<JsonRecipes> catList = new List<JsonRecipes>();
                catList.AddRange(cat as List<JsonRecipes>);


                List<NgData.Models.Recipe> recipes = new List<NgData.Models.Recipe>();


                //foreach (var item in cat as List<JsonRecipes>)
                for (int i = 0; i < catList.Count(); i++)
                {
                    List<NgData.Models.Ingredient> ingredients = new List<NgData.Models.Ingredient>();
                    List<NgData.Models.Comment> comments = new List<NgData.Models.Comment>();
                    NgData.Models.Recipe recipe = new NgData.Models.Recipe();

                    foreach (var ingr in catList[i].ingredients.ToList())
                    {
                        ingredients.Add(context.Ingredients.Where(m => m.Id == ingr).SingleOrDefault());
                    }

                    if (catList[i].comments != null)
                    {
                        foreach (var com in catList[i].comments.ToList())
                        {
                            comments.Add(new NgData.Models.Comment { Mark = com.mark, RecipeId = catList[i].id, Text = com.comment, Title = com.title, UserId = com.userId });
                        }
                    }

                    recipe.Ingredients = ingredients;
                    recipe.Comments = comments;
                    recipe.Calories = catList[i].calories;
                    recipe.Id = catList[i].id;
                    recipe.IsAvailable = catList[i].isAvailable;
                    recipe.Name = catList[i].name;
                    recipe.Picture = catList[i].picture;
                    recipe.Preparation = catList[i].preparation;
                    recipe.UserId = catList[i].creatorId;

                    recipes.Add(recipe);


                }

                context.Recipes.AddRange(recipes);
                context.SaveChanges();
            }
        }
    }
}