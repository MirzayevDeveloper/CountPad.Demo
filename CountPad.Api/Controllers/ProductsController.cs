using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace CountPad.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost]
		public async ValueTask<IActionResult> PostProductAsync(Product product)
		{
			Product response = await _productService.AddProductAsync(product);

			return Ok(response);
		}
	}
}
