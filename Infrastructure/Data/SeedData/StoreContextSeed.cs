using Core.Entities;
using Infrastructure.Context;
using System.Text.Json;

namespace Infrastructure.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null)
                {
                    await context.Products.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }
            await Task.CompletedTask;
        }
    }
}
