using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Distributors;
using Microsoft.AspNetCore.Mvc;

namespace CountPad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorsController:ControllerBase
    {
        private readonly IDistributorService _distributorService;

        public DistributorsController(IDistributorService distributorService)
        {
            _distributorService= distributorService;
        }

        [HttpPost]
        public async ValueTask<ActionResult> PostDistributorAsync(Distributor distributor)
        {
            var response = await _distributorService.AddDistributorAsync(distributor);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult> GetDistributorAsync(Guid id)
        {
            var response=await _distributorService.GetDistributorByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<ActionResult> GetAllDistributorsAsync()
        {
            IQueryable<Distributor> response = _distributorService.GetAllDistributors();

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<ActionResult> UpdateDistributorAsync(Distributor distributor)
        {
            var response = await _distributorService.UpdateDistributorAsync(distributor);

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<ActionResult> DeleteDistributorAsync(Guid id)
        {
            var response = await _distributorService.DeleteDistributorAsync(id);

            return Ok(response);
        }
    }
}
