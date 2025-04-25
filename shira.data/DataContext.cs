using Microsoft.EntityFrameworkCore;
using shira.core.Entities;

namespace shira.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

    }
}
