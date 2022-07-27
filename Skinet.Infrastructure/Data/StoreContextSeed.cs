using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Skinet.Core.Entities;

namespace Skinet.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var path = "../Skinet.Infrastructure/SeedData/brands.json";
                    var brandsData = File.ReadAllText(path);

                    var brand = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var productBrand in brand)
                    {
                        context.ProductBrands.Add(productBrand);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var path = "../Skinet.Infrastructure/SeedData/types.json";

                    var typesData = File.ReadAllText(path);

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var productType in types)
                    {
                        context.ProductTypes.Add(productType);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var path = "../Skinet.Infrastructure/SeedData/products.json";
                    var productsData = File.ReadAllText(path);

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();

                logger.LogError(e.Message);
            }
        } 
    }
}
