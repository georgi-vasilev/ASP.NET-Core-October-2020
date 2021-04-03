using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstAspNetCoreApp.ViewModels.Recipes
{
    public class RecipeTimeInputModel : IValidatableObject
    {
        [Range(1, 24 * 60)]
        public int CookingTime { get; set; }

        [Range(1, 2 * 24 * 60)]
        public int PreparationTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.PreparationTime > this.CookingTime)
            {
                yield return new ValidationResult("Prep. time cannot be more than cooking time.");
            }
            if (this.PreparationTime + this.CookingTime > 2.5 * 24 * 60)
            {
                yield return new ValidationResult("Prep. time + cooking time cannot be more than 2 and a half days.");
            }
        }

    }
}
