using EDrinkShop.ApplicationCore.Entities;

namespace EDrinkShop.ApplicationCore.Specifications
{
   public class CatalogFilterPaginatedSpecification : BaseSpecification<CalalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId)
            : base(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId))
        {
            ApplyPaging(skip, take);
        }
    }
}
