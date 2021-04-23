namespace MyApp.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyFirstAspNetCoreApp.Controllers;
    using MyFirstAspNetCoreApp.Data;
    using MyFirstAspNetCoreApp.Models;
    using Xunit;

    public class ProductsControllerTests
    {
        [Fact]
        public void GetShouldReturnTheProductIfFound()
        {
            var product = new Product
            {
                Id = 2,
                Name = "product test",
                Price = 100,
            };
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var controller = new ProductsController(dbContext);

            var result = controller.Get(2);

            Assert.NotNull(result);
            Assert.Equal("product test", result.Value.Name);
        }

        [Fact]
        public void GetShouldReturnNotFoundIfProductDoesNotExist()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            var controller = new ProductsController(dbContext);

            var result = controller.Get(2);

            Assert.Null(result.Value);
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
