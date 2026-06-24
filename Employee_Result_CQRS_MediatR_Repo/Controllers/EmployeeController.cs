using Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Command;
using Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Query;

namespace Employee_Result_CQRS_MediatR_Repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllEmployeeQuery());
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetByIDEmployeeQuery(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateCommand cmdobj)
        {
            if (id != cmdobj.Id)
            {
                return BadRequest("Id mismatch");
            }
            var result = await mediator.Send(cmdobj);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateCommand cmdobj)
        {
            var result = await mediator.Send(cmdobj);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new EmployeeDeleteCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }




}}
