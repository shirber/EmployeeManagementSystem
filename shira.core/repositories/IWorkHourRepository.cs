using shira.core.Entities;

namespace shira.core.repositories
{
    public interface IWorkHourRepository
    {
        Task<IEnumerable<WorkHour>> GetAllAsync();
        Task<WorkHour> GetByIdAsync(int id);
        Task AddAsync(WorkHour workHour);
        Task UpdateAsync(WorkHour workHour);
        Task DeleteAsync(int id);
    }
}
