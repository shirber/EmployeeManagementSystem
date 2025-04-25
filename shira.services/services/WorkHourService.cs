using shira.core.Entities;
using shira.core.repositories;
using shira.core.services;

namespace shira.services.services
{
    public class WorkHourService : IWorkHourService
    {
        private readonly IWorkHourRepository _repo;

        public WorkHourService(IWorkHourRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<WorkHour>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<WorkHour> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(WorkHour workHour) => await _repo.AddAsync(workHour);
        public async Task UpdateAsync(WorkHour workHour) => await _repo.UpdateAsync(workHour);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
