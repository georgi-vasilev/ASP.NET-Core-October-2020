namespace MyRecipes.Services.Data
{
    using MyRecipes.Services.Data.DTOs;

    public interface IGetCountsService
    {
        // 1. Use the view model
        // 2. Create DTO -> view model
        // 3. Tuples
        CountsDto GetCounts();
    }
}
