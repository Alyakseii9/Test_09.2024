namespace My_1_w.Application.Core.Entities
{
    public sealed class CatalogBrand
    { //Toodo replace to guid
        public int Id { get; set; }
        public string Brand { get; set; }

        public CatalogBrand(string brand)
        {
            Brand = brand;
        }
    }
}
