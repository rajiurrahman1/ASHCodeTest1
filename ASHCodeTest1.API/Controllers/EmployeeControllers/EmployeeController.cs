using ASH.CodeTest.Common.Models;
using ASH.CodeTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASHCodeTest1.API.Controllers.EmployeeControllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private IEmployeeService _employeeServices;
    public EmployeeController(IEmployeeService empService) {
        _employeeServices = empService;
    }

    [HttpGet]
    [Route("employees")]
    //[Authorize]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _employeeServices.GetEmployees();

        return Ok(employees);
    }

    [HttpGet]
    [Route("employee/{employeeId}")]
    public async Task<IActionResult> GetEmployee(int employeeId)
    {
        if (employeeId < 1)
            return BadRequest("Please provide a valid employeeId");

        var employee = await _employeeServices.GetEmployee(employeeId);

        if (employee == null)
            return NotFound($"Employee was not found for ID: {employeeId}");

        return Ok(employee);
    }

    [HttpPost]
    [Route("addEmployee")]
    public async Task<IActionResult> AddEmployee(Employee employee)
    {
        //Use FluentValidation to check the validity of input parameters here
        //Didn't get enough time to implement validation 

        int insertedEmployeeId = await _employeeServices.AddEmployee(employee);

        return Ok(employee);
    }
}
