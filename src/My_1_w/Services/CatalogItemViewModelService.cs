using Microsoft.AspNetCore.Mvc.Rendering;
using My_1_w.Application.Core.Entities;
using My_1_w.Application.Core.Interfaces;
using My_1_w.Interfaces;
using My_1_w.Models;
using System.Linq;

namespace My_1_w.Services
{
    public sealed class CatalogItemViewModelService : ICatalogItemViewModelService
    {
        private readonly IRepository<CatalogItem> _catalogItemRepository;
        private readonly IRepository<CatalogBrand> _brandRepository;
        private readonly IRepository<CatalogType> _typeRepository;
        private readonly IAppLogger<CatalogItemViewModelService> _logger;

        public CatalogItemViewModelService(
            IRepository<CatalogItem> catalogItemRepository,
            IAppLogger<CatalogItemViewModelService> logger,
            IRepository<CatalogBrand>brandRepository,
             IRepository<CatalogType> typeRepository)
        {
            _catalogItemRepository = catalogItemRepository;//<--сюда будет приходить целый объект,создаваемый фреймйорком//new LocalCatalogItemRepository();
            _logger = logger;
            _brandRepository = brandRepository;
            _typeRepository = typeRepository;
        }

        public async Task<CatalogIndexViewModel> GetCatalogItems(int? brandId, int? typeId)   
        {
          var entities = await _catalogItemRepository.GetAllAsync();
            var catalogItems = entities
                .Where(item=>(!brandId.HasValue || item.CatalogBrandId == brandId)
                 &&(!typeId.HasValue || item.CatalogTypeId==typeId))
                .Select(item => new CatalogItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                PictureUrl = item.PictureUrl,
                Price = item.Price,
            }).ToList();

            var vm = new CatalogIndexViewModel()
            {
                CatalogItems = catalogItems,
                Brands = (await GetBrands()).ToList(),
                Types = (await GetBrands()).ToList(),
            };
            return vm;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrands()
        {
            _logger.LogInformation("Get Brands called,");
            var brands = await _brandRepository.GetAllAsync();

            var items = brands
                .Select(brand => new SelectListItem() { Value=brand.Id.ToString(),Text=brand.Brand})
                .OrderBy(brand=>brand.Text)
                .ToList();

            var allitem = new SelectListItem() {Value=null, Text="All", Selected=true };

            items.Insert(0, allitem);
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {
            _logger.LogInformation("Get Types called,");
            var types = await _typeRepository.GetAllAsync();

            var items = types                                                                 //00.38.51--11-го вебинара
                .Select(_ => new SelectListItem() { Value = _.Id.ToString(), Text = _.Type })//здесь "_" тоже самое,что "types"--как фишка от Вадима
                .OrderBy(_ => _.Text)
                .ToList();

            var allitem = new SelectListItem() { Value = null, Text = "All", Selected = true };

            items.Insert(0, allitem);
            return items;
        }

        public void UpdateCatalogItem(CatalogItemViewModel viewModel)
        {
            var existingCatalogItem = _catalogItemRepository.GetbyId(viewModel.Id);
            if (existingCatalogItem is null)
            {
                var exception = new Exception($"Catalog item{viewModel.Id} was not found");
                _logger.LogError(exception, exception.Message);
                throw exception;
            }
               
            
            CatalogItem.CatalogItemDetails detail = new(viewModel.Name, viewModel.Price);
            existingCatalogItem.UpdateDetails(detail);

            _logger.LogInformation($"Updating catalog item {existingCatalogItem.Id}."+
                $"Name {existingCatalogItem.Name}."+
                $"Price {existingCatalogItem.Price}");
            _catalogItemRepository.Update(existingCatalogItem);
        }
    }
}
