using Microsoft.EntityFrameworkCore;
using shira.core.Entities;
using shira.core.repositories;

namespace shira.data.repositories
{
    public class employeeRepositories : IemployeeRepositories
    {
        private readonly DataContext _context;

        public employeeRepositories(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddAsync(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Employee emp)
        {
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
        }
    }
}
