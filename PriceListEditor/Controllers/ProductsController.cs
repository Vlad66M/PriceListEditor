using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PriceListEditor.Helpers;
using PriceListEditor.Models;
using PriceListEditor.Persistence.Repositories;
using PriceListEditor.Persistence.Repositories.Contracts;
using PriceListEditor.Services.Contracts;
using PriceListEditor.ViewModels;

namespace PriceListEditor.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IFeaturesRepository _featuresRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IProductsService _productsService;

        public ProductsController(IFeaturesRepository featuresRepository,
                                  IProductsRepository productsRepository,
                                  IProductsService productsService)
        {
            _featuresRepository = featuresRepository;
            _productsRepository = productsRepository;
            _productsService = productsService;
        }

        [HttpGet("/products/{id:int}")]
        public async Task<IActionResult> Product(int id)
        {
            var product = await _productsRepository.GetById(id);
            var features = await _featuresRepository.GetByProductId(id);
            ProductDetailsVM detailsVM= new ProductDetailsVM() { Product = product, Features =  features };
            return View(detailsVM);
        }

        [HttpGet("/create_product/{id:int}")]
        public async Task<IActionResult> Create(int id)
        {
            ViewData["features"] = await _featuresRepository.GetByPriceListId(id);
            ViewData["price_list_id"] = id;
            return View("Create");
        }

        [HttpPost("/create_product/{id:int}")]
        public async Task<IActionResult> Create(int id, CreateProductVM createProductVM)
        {
            if (!ModelState.IsValid)
            {
                ValidationHelper.AddErrorMessagesToProduct(ModelState, createProductVM);
                ViewData["features"] = await _featuresRepository.GetByPriceListId(id);
                ViewData["price_list_id"] = id;
                return View(createProductVM);
            }
            await _productsService.CreateProduct(createProductVM);
            return RedirectToAction("PriceList", "PriceList", new {id = createProductVM.PriceListId});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int PriceListId, int ProductId)
        {
            await _productsRepository.Delete(ProductId);
            return RedirectToAction("PriceList", "PriceList", new { id = PriceListId });
        }   
    }
}
