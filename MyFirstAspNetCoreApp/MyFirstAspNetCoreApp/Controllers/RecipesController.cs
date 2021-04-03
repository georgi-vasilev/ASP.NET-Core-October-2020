using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApp.Models;
using MyFirstAspNetCoreApp.ViewModels.Recipes;
using System;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Add()
        {
            //creating default valus in the form for the user
            var model = new AddRecipeInputModel
            {
                Type = RecipeType.Unknown,
                FirstCooked = DateTime.UtcNow,
                Time = new RecipeTimeInputModel()
                {
                    CookingTime = 10,
                    PreparationTime = 5
                },
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Add(AddRecipeInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
