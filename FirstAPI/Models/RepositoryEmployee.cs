using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace FirstAPI.Models
{
    public class RepositoryEmployee
    {
        public readonly NorthwindContext _northwindContext; 
        public RepositoryEmployee(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
		//Get All Employees
		public List<Employee> EmployeeDetails()
		{
			return _northwindContext.Employees.ToList();
		}
        //Get Employee by Id
        public Employee EmployeeDetailsById(int id)
        {
            return _northwindContext.Employees.Find(id);
        }
        public int UpdateEmployee(Employee employee)
        {
            _northwindContext.Employees.Update(employee);
            return _northwindContext.SaveChanges();
        }
        public int AddEmployee(Employee employee)
        {
            _northwindContext.Employees.Add(employee);
            return _northwindContext.SaveChanges();
        }
        public int DeleteEmployee(int id)
        {
            var employee = _northwindContext.Employees.Find(id);
            _northwindContext.Employees.Remove(employee);
            return _northwindContext.SaveChanges();
        }

	}
    

    }
