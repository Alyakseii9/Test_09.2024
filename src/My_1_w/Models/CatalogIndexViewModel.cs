using Microsoft.AspNetCore.Mvc.Rendering;

namespace My_1_w.Models
{
    public  sealed class CatalogIndexViewModel
    {
        public List<CatalogItemViewModel>? CatalogItems { get; set; }
        public List<SelectListItem>? Brands { get; set; }
        public List<SelectListItem>? Types { get; set; }
        public int? BrandFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }
    }
}
