using ESchoolApi.Interfaces;
using ESchoolApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESchoolApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]  
public class AuthController : Controller
{
    private readonly IJWTManagerRepository _jWTManager;
    private readonly IRequest<User> _userRepo;

    public AuthController(IRequest<User> IUser, IJWTManagerRepository jWTManager)
    {
        _userRepo = IUser;
        _jWTManager = jWTManager;
    }
    
    //GET: api/employee>
    // [HttpGet]
    // public async Task<ActionResult<IRequest<User>>> Get()
    // {
    //     return await Task.FromResult(_userRepo.GetAll());
    // }

    [AllowAnonymous]
    [HttpPost]
    [Route("authenticate")]
    public IActionResult Authenticate(User usersdata)
    {
        var token = _jWTManager.Authenticate(usersdata);

        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }
    
    // GET api/employee/5
    // [HttpGet("{id}")]
    // public async Task<ActionResult<User>> Get(int id)
    // {
    //     var employees = await Task.FromResult(_IEmployee.GetEmployeeDetails(id));
    //     if (employees == null)
    //     {
    //         return NotFound();
    //     }
    //     return employees;
    // }
    //
    // // POST api/employee
    // [HttpPost]
    // public async Task<ActionResult<Employee>> Post(Employee employee)
    // {
    //     _IEmployee.AddEmployee(employee);
    //     return await Task.FromResult(employee);
    // }
    //
    // // PUT api/employee/5
    // [HttpPut("{id}")]
    // public async Task<ActionResult<Employee>> Put(int id, Employee employee)
    // {
    //     if (id != employee.EmployeeID)
    //     {
    //         return BadRequest();
    //     }
    //     try
    //     {
    //         _IEmployee.UpdateEmployee(employee);
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!EmployeeExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }
    //     return await Task.FromResult(employee);
    // }
    //
    // // DELETE api/employee/5
    // [HttpDelete("{id}")]
    // public async Task<ActionResult<Employee>> Delete(int id)
    // {
    //     var employee = _IEmployee.DeleteEmployee(id);
    //     return await Task.FromResult(employee);
    // }
    //
    // private bool EmployeeExists(int id)
    // {
    //     return _IEmployee.CheckEmployee(id);
    // }
}
