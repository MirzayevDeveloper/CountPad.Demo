﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using CountPad.Application.DTOs;
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
		public async ValueTask<IActionResult> PostProductAsync(ProductDto productDto)
		{
			Product response = await _productService.AddProductAsync(new()
			{
				Id = Guid.NewGuid(),
				Name = productDto.Name,
				Description = productDto.Description,
				ProductType = productDto.ProductType,
			});

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async ValueTask<IActionResult> GetProductAsync(Guid id)
		{
			Product maybeProduct = await _productService.GetProductByIdAsync(id);

			return Ok(maybeProduct);
		}

		[HttpGet]
		public async ValueTask<IActionResult> GetAllProdoductsAsync()
		{
			IQueryable<Product> products = _productService.GetAllProducts();

			return Ok(products);
		}

		[HttpPut]
		public async ValueTask<IActionResult> UpdateProductAsync(Product product)
		{
			Product maybeProduct = await _productService.UpdateProductAsync(product);

			return Ok(maybeProduct);
		}

		[HttpDelete]
		public async ValueTask<IActionResult> DeleteProductAsync(Guid productId)
		{
			Product maybeProduct = await _productService.DeleteProductAsync(productId);

			return Ok(maybeProduct);
		}
	}
}
