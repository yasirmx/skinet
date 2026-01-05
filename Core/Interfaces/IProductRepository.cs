using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product> GetProductById(int id);

        public Task AddProduct(Product product);

        public Task UpdateProduct(Product product);

        public Task DeleteProduct(int id);

        public Task<IReadOnlyList<string>> GetBrands();

        public Task<IReadOnlyList<string>> GetTypes();
    }
}
