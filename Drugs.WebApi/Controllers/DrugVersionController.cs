using AutoMapper;
using Drugs.Application.DrugVersions.Commands.CreateDrugVersion;
using Drugs.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drugs.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DrugVersionController : BaseController
    {
        private readonly IMapper _mapper;

        public DrugVersionController(IMapper mapper) => _mapper = mapper;

        public async Task<ActionResult<Guid>> CreateDrugVersion([FromBody] CreateDrugVersionDto createDrugVersionDto)
        {
            var command = _mapper.Map<CreateDrugVersionCommand>(createDrugVersionDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}
