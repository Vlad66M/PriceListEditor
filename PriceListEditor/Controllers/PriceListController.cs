using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PriceListEditor.Persistence.Repositories.Contracts;
using PriceListEditor.Services.Contracts;
using PriceListEditor.ViewModels;

namespace PriceListEditor.Controllers
{
    public class PriceListController : Controller
    {
        private readonly IPriceListsRepository _priceListsRepository;
        private readonly IFeaturesRepository _featuresRepository;
        private readonly IPriceListService _priceListService;

        public PriceListController(IPriceListsRepository priceListsRepository,
                                   IFeaturesRepository featuresRepository,
                                   IPriceListService priceListService) 
        {
            _priceListsRepository = priceListsRepository;
            _featuresRepository = featuresRepository;
            _priceListService = priceListService;
        }

        [HttpGet("/price_lists")]
        public async Task<IActionResult> Index(int? page)
        {
            var priceLists = await _priceListsRepository.GetAll(page);
            return View(priceLists);
        }

        [HttpGet("/get_pice_lists_json")]
        public async Task<string> GetJson(string? page)
        {
            int p = 1;
            try
            {
                p = int.Parse(page);
            }
            catch { }
            var priceLists = await _priceListsRepository.GetAll(p);
            var json = JsonConvert.SerializeObject(priceLists);
            return json;
        }

        [HttpGet("/create_price_list")]
        public async Task<IActionResult> Create()
        {
            var existingFeatures = await _featuresRepository.GetAll();
            ViewData["features"] = existingFeatures;
            return View();
        }

        [HttpPost("/create_price_list")]
        public async Task<IActionResult> Create(PriceListVM priceListVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Неверно заполнены поля");
                ViewData["features"] = await _featuresRepository.GetAll();
                return View();
            }
            await _priceListService.CreatePriceList(priceListVM);
            return RedirectToAction("Index");
        }

        [HttpGet("/price_lists/{id:int}")]
        public async Task<IActionResult> PriceList(int id, int? page = null, int? orderby = null, bool? asc = null)
        {
            var model = await _priceListsRepository.GetDetails(id, page, orderby, asc);
            ViewData["price_list_id"] = id;
            return View(model);
        }

        [HttpGet("/get_products_list_json/{id:int}")]
        public async Task<string> GetProductsJson(int id, int? page, int? orderby = null, bool? asc = null)
        {
            var products = await _priceListsRepository.GetDetails(id, page, orderby, asc);
            var json = JsonConvert.SerializeObject(products, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
            return json;
        }

    }
}
