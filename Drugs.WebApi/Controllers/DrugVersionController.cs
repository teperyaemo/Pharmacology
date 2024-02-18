using AutoMapper;
using Drugs.Application.Drugs.Commands.DeleteCommand;
using Drugs.Application.DrugVersions.Commands.CreateDrugVersion;
using Drugs.Application.DrugVersions.Commands.DeleteDrugVersion;
using Drugs.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Drugs.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DrugVersionController : BaseController
    {
        private readonly IMapper _mapper;

        public DrugVersionController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDrugVersion([FromBody] CreateDrugVersionDto createDrugVersionDto)
        {
            var command = _mapper.Map<CreateDrugVersionCommand>(createDrugVersionDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteDrugVersionCommand
            {
                VersionId = id
            };
            var unit = await Mediator.Send(command);
            return NoContent();
        }
    }
}
