using CQRSMediaTr.Data;
using CQRSMediaTr.Features.Employees.Command;
using CQRSMediaTr.Features.Employees.Query;
using CQRSMediaTr.Model.Domain;
using CQRSMediaTr.Model.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CQRSMediaTrDbContext _context;
        private readonly IMediator _mediator;

        public EmployeesController(CQRSMediaTrDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            //var employees = await _context.Employees.ToListAsync();
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpGet("GetEmployeesByName")]
        public async Task<IActionResult> GetEmployeesByName([FromQuery] string name)
        {
            var employees = await _mediator.Send(new GetEmployeesByNameQuery(name));
            if ((employees == null))
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var IsDeleted = await _mediator.Send(new DeleteEmployeeCommand(id));
            if (IsDeleted == false) return NotFound();
            return Ok(IsDeleted);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            var response =await  _mediator.Send(new CreateEmployeeCommand(employee));

            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateDTO employeeUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _mediator.Send(new UpdateEmployeeCommand(id,employeeUpdateDTO));
            return Ok(response);

        }
    }
}
