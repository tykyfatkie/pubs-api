using System;
using System.Collections.Generic;
using System.Linq;
using pubs1.Models;

namespace pubs1.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PUBSContext _context;

        public EmployeeService(PUBSContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(string id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmpId == id);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.EmpId == employee.EmpId);
            if (existingEmployee != null)
            {
                existingEmployee.Fname = employee.Fname;
                existingEmployee.Minit = employee.Minit;
                existingEmployee.Lname = employee.Lname;
                existingEmployee.JobId = employee.JobId;
                existingEmployee.JobLvl = employee.JobLvl;
                existingEmployee.PubId = employee.PubId;
                existingEmployee.HireDate = employee.HireDate;

                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(string id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmpId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
