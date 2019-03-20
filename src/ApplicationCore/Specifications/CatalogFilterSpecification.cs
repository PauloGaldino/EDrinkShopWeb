
using EDrinkShop.ApplicationCore.Entities;

namespace EDrinkShop.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification : BaseSpecification<CalalogItem>
    {
        public CatalogFilterSpecification(int? brandId, int? typeId)
            : base(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId))
        {
        }
    }
}
