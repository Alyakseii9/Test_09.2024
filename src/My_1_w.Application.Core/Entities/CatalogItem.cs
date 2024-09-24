namespace My_1_w.Application.Core.Entities
{
    public sealed class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
       
        public int CatalogTypeId { get; set; }
        public CatalogType? CatalogType { get; set; }
       
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }   

        public CatalogItem(int catalogTypeId,
        int catalogBrandId,
        string description,
        string name,
        decimal price,
        string pictureUrl)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
            Description = description;
            Name = name;
            Price = price;
            PictureUrl = pictureUrl;
        }

        public CatalogItem(int id, string name, string description, decimal price, string pictureUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
        }

        public void UpdateDetails(CatalogItemDetails details)
        {
            Name = details.Name;
            //   Description = details.Description;
            Price = details.Price;
        }

        public readonly record struct CatalogItemDetails
        {
            public string? Name { get; }

            //    public string? Description { get; }---------2.49.24-----5-webinar
            public decimal Price { get; }

            public CatalogItemDetails(string? name,/* string? description,*/ decimal price)
            {
                Name = name;
                //         Description = description;
                Price = price;
            }
        }
    }
}
