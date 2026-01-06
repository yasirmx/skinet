using Core.Entities;
using Core.Interfaces;
using Core.Pagination;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skinet.Api.Controllers
{

    public class ProductsController(IGenericRepository<Product> productRepository) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery] ProductSpecificationParameter productSpecificationParameter)
        {
            var spec = new ProductSpecification(productSpecificationParameter);

            return await CreatePagedResult(productRepository, spec, productSpecificationParameter.PageIndex, productSpecificationParameter.PageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productRepository.GetById(id);

            if (product == null)
                return NotFound();
            
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if(product == null)
                return BadRequest("Product cannot be null");

            await productRepository.Add(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id || !await ProductExists(id))
                return BadRequest("Cannot update this product");

           await productRepository.Update(product);

           return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id, Product product)
        {
            if(await ProductExists(id) == false)
                return BadRequest("Cannot delete this product");

            await productRepository.Delete(product);

            return NoContent();
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetProductBrands()
        {
            return Ok((await productRepository.ListWithSpecification(new BrandSpecification())));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
        {
            return Ok((await productRepository.ListWithSpecification(new TypeSpecification())));
        }

        private async Task<bool> ProductExists(int id)
        {
            return await productRepository.GetById(id) != null;
        }
    }
}
