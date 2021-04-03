using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApp.ModelBinder
{
    public class ExtractYearModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext context)
        {
            var value = context.ValueProvider.GetValue("firstcooked").FirstValue;
            if (DateTime.TryParse(value, out var valueAsDateTime))
            {
                context.Result = ModelBindingResult.Success(valueAsDateTime.Year);
            }
            else
            {
                context.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
