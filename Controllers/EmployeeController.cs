using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Web_API_and_EFcore.Data;
using Web_API_and_EFcore.Models;

namespace Web_API_and_EFcore.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class EmployeeController : Controller
{
    private EmployeeDbContext DbContext;

    public EmployeeController(EmployeeDbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetEmployee()
    {
        return Ok(await DbContext.MyProperty.ToListAsync());
        
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetEmploee([FromRoute] Guid id)
    {
        var employee = await DbContext.MyProperty.FindAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);

    }

    [HttpPost]
    public async Task<IActionResult>  AddNewEmployee(AddEmployee addEmployee)
    {
        var employee = new Employee()
        {
            Id = Guid.NewGuid(),
            FullName = addEmployee.FullName,
            Email = addEmployee.Email,
            Phone = addEmployee.Phone

        };
        await DbContext.MyProperty.AddAsync(employee);
        await DbContext.SaveChangesAsync();

        return Ok(employee); 
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, UpdateEmoployeeDts updateEmoployeeDts)
    {
        var employee = await DbContext.MyProperty.FindAsync(id);
        
            if (id != null)
            {
                employee.FullName = updateEmoployeeDts.FullName;
                employee.Email = updateEmoployeeDts.Email;
                employee.Phone = updateEmoployeeDts.Phone;

                await DbContext.SaveChangesAsync();
                return Ok(employee);
            }

            return NotFound();
        

    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var employee = await DbContext.MyProperty.FindAsync(id);
        if (employee != null)
        {
            DbContext.Remove(employee);
            await DbContext.SaveChangesAsync();
            return Ok("Successfully Deleted....");
        }

        return NotFound();
    }

}