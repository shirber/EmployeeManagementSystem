using shira.core.Entities;
using shira.core.repositories;
using shira.core.services;

namespace shira.services.services
{
    public class employeeServices : IemployeeServices
    {
        private readonly IemployeeRepositories _repo;

        public employeeServices(IemployeeRepositories repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(Employee emp)
        {
            await _repo.AddAsync(emp);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task UpdateAsync(Employee emp)
        {
            await _repo.UpdateAsync(emp);
        }
    }
}
