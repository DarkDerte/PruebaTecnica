using Microsoft.AspNetCore.Mvc;
using Web.Business.DTO;
using Web.Business.Interfaces;

namespace Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly ILogger<ContractController> _logger;
        private readonly IContractService _contractService;

        public ContractController(ILogger<ContractController> logger, IContractService contractService)
        {
            _logger = logger;
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDTO>>> All()
        {
            return Ok(await _contractService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ContractDTO>> Get(ulong id)
        {
            var res = await _contractService.GetContractAsync(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContractDTO contractNew)
        {
            await _contractService.InsertAsync(contractNew);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ContractDTO contractNew)
        {
            await _contractService.UpdateAsync(contractNew);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(ulong id)
        {
            await _contractService.DeleteAsync(id);
            return Ok();
        }
    }
}
