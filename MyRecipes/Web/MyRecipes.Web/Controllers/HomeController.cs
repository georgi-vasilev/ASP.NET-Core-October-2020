namespace MyRecipes.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels;
    using MyRecipes.Web.ViewModels.Home;

    // 1.ApplicationDbContext
    // 2.Repositories
    // 3. Services
    public class HomeController : BaseController
    {
        private readonly IGetCountsService service;

        public HomeController(IGetCountsService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var countsDto = this.service.GetCounts();

            ////var viewModel = this.mapper.Map<IndexViewModel>(countsDto);

            var viewModel = new IndexViewModel
            {
                CategoriesCount = countsDto.CategoriesCount,
                ImagesCount = countsDto.ImagesCount,
                RecipesCount = countsDto.RecipesCount,
                IngredientsCount = countsDto.IngredientsCount,
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
