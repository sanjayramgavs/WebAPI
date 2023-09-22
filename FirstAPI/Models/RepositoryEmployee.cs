using System;
using System.Collections.Generic;
using System.Linq;
using FirstAPI.Models;

public class RepositoryEmployee
{
    private readonly NorthwindContext _dbContext;

    public RepositoryEmployee(NorthwindContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Employee> EmployeeDetails()
    {
        try
        {
            return _dbContext.Employees.ToList();
        }
        catch (Exception ex)
        {
           
            throw ex;
        }
    }

    public Employee EmployeeDetailsById(int id)
    {
        try
        {
            return _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }
        catch (Exception ex)
        {
           
            throw ex;
        }
    }

    public int AddEmployee(Employee employee)
    {
        try
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee.EmployeeId;
        }
        catch (Exception ex)
        {
           
            throw ex;
        }
    }

    public int UpdateEmployee(Employee employee)
    {
        try
        {
            Employee existingEmployee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee == null)
            {
                return 0; 
            }
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Title = employee.Title;
            existingEmployee.BirthDate = employee.BirthDate;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.City = employee.City;
            existingEmployee.ReportsTo = employee.ReportsTo;

            _dbContext.SaveChanges();
            return existingEmployee.EmployeeId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteEmployee(int id)
    {
        try
        {
            Employee employeeToDelete = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employeeToDelete == null)
            {
                return 0;
            }

            _dbContext.Employees.Remove(employeeToDelete);
            _dbContext.SaveChanges();
            return id;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public EmpViewModel MapEmployeeToEmpViewModel(Employee employee)
    {
        return new EmpViewModel
        {
            EmpId = employee.EmployeeId,
            Firstname = employee.FirstName,
            Lastname = employee.LastName,
            Title = employee.Title,
            Birthdate = employee.BirthDate,
            Hiredate = employee.HireDate,
            city = employee.City,
            ReportsTo = employee.ReportsTo
        };
    }

    public Employee MapEmpViewModelToEmployee(EmpViewModel empViewModel)
    {
        return new Employee
        {
            FirstName = empViewModel.Firstname,
            LastName = empViewModel.Lastname,
            Title = empViewModel.Title,
            BirthDate = empViewModel.Birthdate,
            HireDate = empViewModel.Hiredate,
            City = empViewModel.city,
            ReportsTo = empViewModel.ReportsTo
        };
    }
}
