using System.Text.Json;
using System.Text.Json.Serialization;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		public readonly RepositoryEmployee _repositoryEmployee;
		public EmployeeController(RepositoryEmployee repositoryEmployee)
		{
			_repositoryEmployee = repositoryEmployee;
		}
	  [HttpGet]
	  public List<Employee> GetEmployees()
	  {
		  return _repositoryEmployee.EmployeeDetails();
	  } 
	  [HttpGet("{serachid}")]
	  public Employee GetEmployeeById(int id)
	  {
		  return _repositoryEmployee.EmployeeDetailsById(id);
	  }
	  // update employee
	  [HttpPut]
	  public int UpdateEmployee(Employee employee)
	  {
		  return _repositoryEmployee.UpdateEmployee(employee);
	  }
	  // add employee
	  [HttpPost]
	  public int AddEmployee(Employee employee)
	  {
		  return _repositoryEmployee.AddEmployee(employee);
	  }
	  // delete employee
	  [HttpDelete("{deleteid}")]
	  public int DeleteEmployee(int id)
	  {
		  return _repositoryEmployee.DeleteEmployee(id);
	  }

	}
}
	