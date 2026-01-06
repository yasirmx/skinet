using Core.Entities;

namespace Core.Specifications
{
    public class TypeSpecification : SpecificationsBase<Product, string>
    {
        public TypeSpecification()
        {
            AddSelect(x => x.Type);
            ApplyDistinct();
        }
    }
}
