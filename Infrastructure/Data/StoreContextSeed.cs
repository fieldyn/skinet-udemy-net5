using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
  public class StoreContextSeed
  {
    public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
    {
      var logger = loggerFactory.CreateLogger<StoreContextSeed>();
      try
      {
        if (!context.ProductBrands.Any())
        {
          var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

          var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

          foreach (var item in brands)
          {
            context.ProductBrands.Add(item);
          }

          await context.SaveChangesAsync();
          logger.LogInformation("ProductBrands created");
        }

        if (!context.ProductTypes.Any())
        {
          var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

          var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

          foreach (var item in types)
          {
            context.ProductTypes.Add(item);
          }

          await context.SaveChangesAsync();
          logger.LogInformation("ProductTypes created");
        }

        if (!context.Products.Any())
        {
          var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

          var products = JsonSerializer.Deserialize<List<Product>>(productsData);

          foreach (var item in products)
          {
            context.Products.Add(item);
          }

          await context.SaveChangesAsync();
          logger.LogInformation("Products created");
        }
      }
      catch (Exception ex)
      {

        logger.LogError(ex.Message);
      }
    }
  }
}