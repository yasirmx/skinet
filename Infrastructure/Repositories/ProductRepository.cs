using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository(StoreContext context) : IProductRepository
    {
        public async Task<IReadOnlyList<string>> GetBrands()
        {
            return await context.Products.Select(p => p.Brand).Distinct().ToListAsync();
        }

        public async Task<IReadOnlyList<string>> GetTypes()
        {
            return await context.Products.Select(p => p.Type).Distinct().ToListAsync();
        }

        public async Task AddProduct(Product product)
        {
            context.Products.Add(product);

            await context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.AsNoTracking().ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;

            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
