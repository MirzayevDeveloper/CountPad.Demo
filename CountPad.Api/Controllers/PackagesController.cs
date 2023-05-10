// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Packages;
using Microsoft.AspNetCore.Mvc;

namespace CountPad.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PackagesController : ControllerBase
	{
		private readonly IPackageService _packageService;

		public PackagesController(IPackageService packageService)
		{
			_packageService = packageService;
		}

		[HttpPost]
		public async ValueTask<IActionResult> AddPackageAsync(Package package)
		{
			Package maybePackage = await _packageService.AddPackageAsync(package);

			return Ok(maybePackage);
		}

		[HttpGet("{id}")]
		public async ValueTask<IActionResult> GetPackageAsync(Guid id)
		{
			Package maybePackage = await _packageService.GetPackageByIdAsync(id);

			return Ok(maybePackage);
		}

		[HttpPut]
		public async ValueTask<IActionResult> UpdatePackageAsync(Package package)
		{
			Package maybePackage = await _packageService.UpdatePackageAsync(package);

			return Ok(maybePackage);
		}

		[HttpDelete]
		public async ValueTask<IActionResult> DeletePackageAsync(Guid id)
		{
			Package package = await _packageService.DeletePackageAsync(id);

			return Ok(package);
		}

		[HttpGet]
		public async ValueTask<IActionResult> GetAllPackages()
		{
			IQueryable<Package> packages = _packageService.GetAllPackageAsync();

			return Ok(packages);
		}
	}
}
