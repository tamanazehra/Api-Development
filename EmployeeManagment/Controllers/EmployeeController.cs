using EmployeeManagment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        //Gets the Data from Database

        [HttpGet]
        public ActionResult<Employee> GetAllEmployees()
        {
            var getAllEmp = _employeeDbContext.Employees.ToList();

            return Ok(getAllEmp);
        }

        //Adds data to database

        [HttpPost]
        public ActionResult CreateEmployee([FromBody] Employee emp)
        { 
            _employeeDbContext.Employees.Add(emp);
            _employeeDbContext.SaveChanges();

            return Ok();
        }

        //Deletes the Data from database

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeToDelete = _employeeDbContext.Employees.Find(id);

            _employeeDbContext.Employees.Remove(employeeToDelete);
            _employeeDbContext.SaveChanges();

            return NoContent(); 
        }

        //Updates the existing Data 

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var existingEmployee = _employeeDbContext.Employees.Find(id);

            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Designation = updatedEmployee.Designation;
            existingEmployee.Address = updatedEmployee.Address;
      
            _employeeDbContext.SaveChanges();

            return NoContent(); 
        }
    }
}
