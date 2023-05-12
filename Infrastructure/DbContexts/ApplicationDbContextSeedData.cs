using Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.DbContexts
{
    public class ApplicationDbContextSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDb,
            ILoggerFactory loggerFactory)
        {
            try
            {
                if(!applicationDb.ProductBrands.Any())
                {
                    var brandData = 
                        File.ReadAllText("../Infrastructure/DbContexts/SeedData/brands.json");
                    
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    
                    foreach (var item in brands)
                    {
                        applicationDb.ProductBrands.Add(item);
                    }

                    await applicationDb.SaveChangesAsync();
                }

                if (!applicationDb.ProductTypes.Any())
                {
                    var typesData =
                        File.ReadAllText("../Infrastructure/DbContexts/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        applicationDb.ProductTypes.Add(item);
                    }

                    await applicationDb.SaveChangesAsync();
                }

                if (!applicationDb.Products.Any())
                {
                    var productData =
                        File.ReadAllText("../Infrastructure/DbContexts/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var item in products)
                    {
                        applicationDb.Products.Add(item);
                    }

                    await applicationDb.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApplicationDbContextSeedData>();
                logger.LogError(ex.Message);
            }
        }
    }
}
