// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Solds;
using Microsoft.AspNetCore.Mvc;

namespace CountPad.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SoldsController : ControllerBase
	{
		private readonly ISoldService _soldService;

		public SoldsController(ISoldService soldService)
		{
			_soldService = soldService;
		}

		[HttpPost]
		public async ValueTask<ActionResult> PostSoldAsync(Sold sold)
		{
			var response = await _soldService.AddSoldAsync(sold);

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async ValueTask<ActionResult> GetSoldByIdAsync(Guid id)
		{
			var response = _soldService.GetSoldByIdAsync(id);

			return Ok(response);
		}

		[HttpPut]
		public async ValueTask<ActionResult> UpdateSoldAsync(Sold sold)
		{
			var response = _soldService.UpdateSoldAsync(sold);

			return Ok(response);
		}

		[HttpDelete]
		public async ValueTask<ActionResult> DeleteSoldAsync(Guid id)
		{
			var response = await _soldService.DeleteSoldAsync(id);

			return Ok(response);
		}

		[HttpGet]
		public IQueryable<ActionResult> GetAllSoldsAsync()
		{
			var response = _soldService.GetAllSoldsAsync();

			return (IQueryable<ActionResult>)Ok(response);
		}
	}
}
