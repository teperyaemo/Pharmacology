using AutoMapper;
using Drugs.Application.Drugs.Commands.CreateDrug;
using Drugs.Application.Drugs.Commands.DeleteCommand;
using Drugs.Application.Drugs.Queries.GetDrug;
using Drugs.Application.Drugs.Queries.GetDrugList;
using Drugs.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Drugs.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DrugController : BaseController
    {
        private readonly IMapper _mapper;
        public DrugController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<DrugListVm>> GetAllDrugs([FromBody] GetAllDrugsDto getAllDrugsDto)
        {
            var query = _mapper.Map<GetDrugListQuery>(getAllDrugsDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrugVm>> GetDrug(Guid id)
        {
            var query = new GetDrugQuery
            {
                DrugId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDrug([FromBody] CreateDrugDto createDrugDto)
        {
            var createDrugcommand = _mapper.Map<CreateDrugCommand>(createDrugDto);
            createDrugcommand.DrugVersion.UserId = UserId;
            var drugId = await Mediator.Send(createDrugcommand);
            return Ok(drugId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteDrugCommand
            {
                DrugId = id
            };
            var unit = await Mediator.Send(command);
            return NoContent();
        }
    }
}
