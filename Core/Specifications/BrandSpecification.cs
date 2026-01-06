using Core.Entities;

namespace Core.Specifications
{
    public class BrandSpecification : SpecificationsBase<Product, string>
    {
        public BrandSpecification()
        {
            AddSelect(x=>x.Brand);
            ApplyDistinct();
        }
    }
}
