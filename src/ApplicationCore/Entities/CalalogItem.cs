namespace EDrinkShop.ApplicationCore.Entities
{
    public class CalalogItem : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescripptiom { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string PictureThumbnailUrl { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
    }
}
