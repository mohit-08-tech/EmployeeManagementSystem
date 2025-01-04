using System;
using EmployeeManagementSystem.Contexts;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _employeeDBContext;

        public EmployeeRepository(EmployeeDBContext context)
        {
            _employeeDBContext = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeDBContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
             return await _employeeDBContext.Employees.FindAsync(id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
             _employeeDBContext.Employees.Add(employee);

            await _employeeDBContext.SaveChangesAsync();

            return await _employeeDBContext.Employees.FirstAsync(e => e.Id == employee.Id);
        }
        

        public async Task UpdateEmployee(Employee employee)
        {
            _employeeDBContext.Entry(employee).State = EntityState.Modified;
            await _employeeDBContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _employeeDBContext.Employees.Remove(employee);
            await _employeeDBContext.SaveChangesAsync();
        }
    }
}
