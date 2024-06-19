using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PriceListEditor.Persistence.Repositories;
using PriceListEditor.Persistence.Repositories.Contracts;
using PriceListEditor.Services.Contracts;
using PriceListEditor.ViewModels;

namespace PriceListEditor.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IFeaturesRepository _featuresRepository;
        private readonly IProductsService _productsService;

        public ProductsController(IFeaturesRepository featuresRepository,
                                  IProductsService productsService)
        {
            _featuresRepository = featuresRepository;
            _productsService = productsService;
        }

        [HttpGet("/create_product/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewData["features"] = await _featuresRepository.GetByPriceListId(id);
            ViewData["price_list_id"] = id;
            return View();
        }

        [HttpPost("/create_product")]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            await _productsService.CreateProduct(createProductVM);
            return RedirectToAction("PriceList", "PriceList", new {id = createProductVM.PriceListId});
        }
    }
}
