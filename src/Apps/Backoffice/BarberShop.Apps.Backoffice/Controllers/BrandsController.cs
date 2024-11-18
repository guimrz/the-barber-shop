using BarberShop.Apps.Backoffice.Models.Brands;
using BarberShop.Apps.Backoffice.Services.Catalog;
using BarberShop.Apps.Backoffice.Services.Catalog.Objects.Request;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Apps.Backoffice.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ILogger _logger;
        private readonly CatalogService _catalogService;

        public BrandsController(ILogger<BrandsController> logger, CatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> List(CancellationToken cancellationToken = default)
        {
            var brands = await _catalogService.GetBrandsAsync(cancellationToken);

            return View(brands.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateBrandViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandViewModel brand, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _catalogService.CreateBrandAsync(new CreateBrandRequest { Name = brand.Name, Description = brand.Description });

            return RedirectToAction(nameof(List));
        }
    }
}
