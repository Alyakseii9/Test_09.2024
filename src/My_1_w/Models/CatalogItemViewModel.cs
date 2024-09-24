using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace My_1_w.Models
{
    public sealed class CatalogItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

      // [BindNever]
        public string PictureUrl { get; set; }

        public decimal Price { get; set; }
    }
}
