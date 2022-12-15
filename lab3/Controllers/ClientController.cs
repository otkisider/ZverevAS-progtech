using lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



namespace lab3.Controllers
{
    public class EmployeeController : Controller
    {
        [Route("api/DateBase")]
        [ApiController]
        public class EmployeeController : ControllerBase
        {
            private readonly Context_context;

                public EmployeeController(Context context)
            {
                _Context = context;
            }
            [HttpGet("GetFull")]
            public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
            {
                if (_context.Employees == null!)
                {
                    return NotFound();
                }
                return await _context.Employees.ToListAsync();

            }

            [HttpGet("Employee/{id}")]
            public async Task<ActionResult<Employee>> GetEmployee(int id)
            {
                if (_context.Employees == null)
                {
                    return NotFound();
                }
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return employee
                }

                [HttpGet("Position/{id}")]
                public async Task<ActionResult<Position>> GetPosition(int id)
                {
                    if (_context.Positions == null)
                    {
                        return NotFound();
                    }
                    var position = await _context.Positions.FindAsync(id);
                    if (position == null)
                    {
                        return position;
                    }

                    [HttpPosition("Employee")]

                    public async Task<ActionResult<Employee>> PositionEmployee(Employee employee)
                    {
                        _сontext.Employees.Add(employee);
                        await _сontext.SaveChangesAsync();

                        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
                    }

                    [HttpPost("Position")]

                    public async Task<ActionResult<Position>> PositionPosition(Position position)
                    {
                        _сontext.Positions.Add(position);
                        await _сontext.SaveChangesAsync();

                        return CreatedAtAction(nameof(GetPosition), new { id = position.Id }, position);
                    }

                    [HttpPut("Employee/{id}")]
                    public async Task<IActionResult> PutEmployee(int id, Employee employee)
                    {
                        if (id != employee.Id)
                        {
                            return BadRequest();
                        }
                        return NoContent();
                    }

                    [HttpPut("Position/{id}")]
                    public async Task<IActionResult> PutPosition(int id, Position position)
                    {
                        if (id != position.Id)
                        {
                            return BadRequest();
                        }
                        return NoContent();
                    }

                    [HttpDelete("Employee/{id}")]
                    public async Task<IActionResult> DeleteEmployee(int id)
                    {
                        if (_сontext.Employees == null)
                        {
                            return NotFound();
                        }
                        var employee = await _сontext.Employees.FindAsync(id);
                        if (employee == null)
                        {
                            return NotFound();
                        }

                        _сontext.Employees.Remove(employee);
                        await _сontext.SaveChangesAsync();

                        return NoContent();
                    }
                    [HttpDelete("Position/{id}")]
                    public async Task<IActionResult> DeletePosition(int id)
                    {
                        if (_сontext.Positions == null)
                        {
                            return NotFound();
                        }
                        var position = await _сontext.Positions.FindAsync(id);
                        if (position == null)
                        {
                            return NotFound();
                        }

                        _сontext.Positions.Remove(position);
                        await _сontext.SaveChangesAsync();

                        return NoContent();

                    }
                }
            }
        }
    }
}