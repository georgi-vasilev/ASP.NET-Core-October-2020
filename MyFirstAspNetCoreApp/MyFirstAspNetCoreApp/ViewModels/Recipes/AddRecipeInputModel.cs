using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyFirstAspNetCoreApp.Models;
using MyFirstAspNetCoreApp.Controllers;
using MyFirstAspNetCoreApp.ValidatioAttributes;
using Microsoft.AspNetCore.Http;

namespace MyFirstAspNetCoreApp.ViewModels.Recipes
{
    public class AddRecipeInputModel
    {
        [Required]
        [MinLength(5)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage ="Name should start with upper letter.")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public RecipeType Type { get; set; }

        //chaging the label name in the ui. label will take this information
        //in order to change it
        [Display(Name="First time the recipe was cooked")]
        [DataType(DataType.Date)]
        public DateTime FirstCooked { get; set; }

        //[ModelBinder(typeof(ExtractYearModelBinder))]
        [CurrentYearMaxValue(1900)]
        public int Year { get; set; }

        public RecipeTimeInputModel Time { get; set; }

        public IFormFile Image { get; set; }
    }
}
