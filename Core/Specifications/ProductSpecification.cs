using Core.Entities;

namespace Core.Specifications
{
    public class ProductSpecification : SpecificationsBase<Product>
    {
        public ProductSpecification(ProductSpecificationParameter productSpecificationParameter) : base(x=> 
        (!productSpecificationParameter.Brands.Any() || productSpecificationParameter.Brands.Contains(x.Brand) &&
        (!productSpecificationParameter.Types.Any() || productSpecificationParameter.Types.Contains(x.Type))))
        {
            switch (productSpecificationParameter.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
                default:
                    break;
            }
        }
    }
}
