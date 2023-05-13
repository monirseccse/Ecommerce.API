using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Specification
{
    public class ProductswithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductswithBrandAndTypeSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductswithBrandAndTypeSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
