using Microsoft.EntityFrameworkCore;
using shira.core.Entities;
using shira.core.repositories;

namespace shira.data.repositories
{
    public class WorkHourRepository : IWorkHourRepository
    {
        private readonly DataContext _context;

        public WorkHourRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkHour>> GetAllAsync()
        {
            return await _context.WorkHours.ToListAsync();
        }

        public async Task<WorkHour> GetByIdAsync(int id)
        {
            return await _context.WorkHours.FindAsync(id);
        }

        public async Task AddAsync(WorkHour workHour)
        {
            _context.WorkHours.Add(workHour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkHour workHour)
        {
            _context.WorkHours.Update(workHour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workHour = await _context.WorkHours.FindAsync(id);
            if (workHour != null)
            {
                _context.WorkHours.Remove(workHour);
                await _context.SaveChangesAsync();
            }
        }
    }
}
