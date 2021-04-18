using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        [HttpGet]
        public Product Test()
        {
            return new Product
            {
                ActiveFrom = DateTime.UtcNow,
                Description = "description",
                Id = 123,
                Name = "name",
                Price = 123.45,
            };
        }

        [HttpPost]
        public Product SoftUni(Product product)
        {
            return product;
        }
    }
}
