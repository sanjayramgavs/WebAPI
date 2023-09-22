using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FirstAPI.Models;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly RepositoryEmployee _repositoryEmployee;

        public EmployeeController(RepositoryEmployee repositoryEmployee)
        {
            _repositoryEmployee = repositoryEmployee;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                List<Employee> employees = _repositoryEmployee.EmployeeDetails();
                List<EmpViewModel> empViewModels = new List<EmpViewModel>();
                foreach (var item in employees)
                {
                    empViewModels.Add(_repositoryEmployee.MapEmployeeToEmpViewModel(item));
                }
                return Ok(empViewModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpGet("{serachid}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                Employee employee = _repositoryEmployee.EmployeeDetailsById(id);
                if (employee == null)
                {
                    return NotFound("Employee not found");
                }
                return Ok(_repositoryEmployee.MapEmployeeToEmpViewModel(employee));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("addemployee")]
        public IActionResult AddEmployee(EmpViewModel employee)
        {
            try
            {
                Employee tempemp = _repositoryEmployee.MapEmpViewModelToEmployee(employee);
                int result = _repositoryEmployee.AddEmployee(tempemp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmpViewModel employee)
        {
            try
            {
                Employee tempemp = _repositoryEmployee.MapEmpViewModelToEmployee(employee);
                tempemp.EmployeeId = id;
                int result = _repositoryEmployee.UpdateEmployee(tempemp);
                if (result == 0)
                {
                    return NotFound("Employee not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpDelete("{deleteid}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                int result = _repositoryEmployee.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound("Employee not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
