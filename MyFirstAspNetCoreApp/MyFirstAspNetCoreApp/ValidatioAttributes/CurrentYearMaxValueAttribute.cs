using System;
using System.ComponentModel.DataAnnotations;

namespace MyFirstAspNetCoreApp.ValidatioAttributes
{
    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        public CurrentYearMaxValueAttribute(int minYear)
        {
            MinYear = minYear;
            this.ErrorMessage = $"Value should be between: {MinYear} and {DateTime.UtcNow.Year}.";
        }

        public int MinYear { get; }

        public override bool IsValid(object value)
        {
            if (value is DateTime dtValue)
            {
                if (dtValue.Year <= DateTime.UtcNow.Year && dtValue.Year >= MinYear)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
