using Microsoft.EntityFrameworkCore;
using pubs1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using pubs1.Services.Interface;

namespace pubs1.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PUBSContext _context;

        public EmployeeRepository(PUBSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(string empId)
        {
            return await _context.Employees.FindAsync(empId);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(string empId)
        {
            var employee = await _context.Employees.FindAsync(empId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
