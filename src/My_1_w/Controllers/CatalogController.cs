using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using My_1_w.Application.Core.Entities;
using My_1_w.Application.Core.Interfaces;
using My_1_w.Interfaces;
using My_1_w.Models;
using My_1_w.Services;

namespace My_1_w.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogItemViewModelService _catalogItemViewModelService;
        private readonly IRepository<CatalogItem> _catalogRepository;
        public CatalogController(
            IRepository<CatalogItem> catalogRrepository,
            ICatalogItemViewModelService catalogItemViewModelService)
        {
            //TODO replace to aioc approach
            _catalogItemViewModelService = catalogItemViewModelService;
            _catalogRepository = catalogRrepository;//new LocalCatalogItemRepository();
        } 
                                                    //это здесь та самая привязка моделей
        public async Task <IActionResult> Index(CatalogIndexViewModel model)
        {
            var viewModel = await _catalogItemViewModelService.GetCatalogItems(model.BrandFilterApplied, model.TypesFilterApplied);
                
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var item = _catalogRepository.GetbyId(id);
            if (item == null) return RedirectToAction("Index");

            var result = new CatalogItemViewModel()
            {
                Id = item.Id,
                Name = item?.Name,
                PictureUrl = item.PictureUrl,
                Price = item.Price,
            };
                return View(result);
        }
                   //роутинг с помощью атрибутов
        [HttpGet("catalog/edit2/{id}")]  //место, где отдаются во вьюшку данные
        //GET: CatalogController/Edit/5
        public IActionResult Edit(int id)
        {
            var item = _catalogRepository.GetbyId(id);
            if (item == null) return RedirectToAction("Index");

            var result = new CatalogItemViewModel()
            {
                Id = item.Id,
                Name = item?.Name,
                PictureUrl = item.PictureUrl,
                Price = item.Price,
            };
            return View(result);
        }

        [HttpPost]  //место, где принмааются данные
        [ValidateAntiForgeryToken]  //это (то что ниже) есть request
        public IActionResult Edit (CatalogItemViewModel catalogItemViewModel)
        {
            try
            {
                _catalogItemViewModelService.UpdateCatalogItem(catalogItemViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
