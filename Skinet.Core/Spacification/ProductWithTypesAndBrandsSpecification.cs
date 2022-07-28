using Skinet.Core.Entities;

namespace Skinet.Core.Spacification;

public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
{
    public ProductWithTypesAndBrandsSpecification()
    {
        AddInclude(b => b.ProductBrand);
        AddInclude(t => t.ProductType);
    }

    public ProductWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(b => b.ProductBrand);
        AddInclude(t => t.ProductType);
    }
}