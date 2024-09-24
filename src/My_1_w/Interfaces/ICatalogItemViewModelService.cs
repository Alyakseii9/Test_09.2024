using Microsoft.AspNetCore.Mvc.Rendering;
using My_1_w.Models;

namespace My_1_w.Interfaces
{
    public interface ICatalogItemViewModelService
    {
        void UpdateCatalogItem(CatalogItemViewModel viewModel);

        Task<CatalogIndexViewModel> GetCatalogItems(int? brandId, int? typeId);//a таk подсказала студия GetCatalogItemsAsync();

        Task<IEnumerable<SelectListItem>> GetBrands();
        Task<IEnumerable<SelectListItem>> GetTypes();
    }
}
