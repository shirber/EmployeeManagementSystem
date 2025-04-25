using shira.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shira.core.repositories
{
   public interface IemployeeRepositories
    {
        Task<IEnumerable<Employee>>GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee emp);
        Task DeleteAsync(int id);
        Task UpdateAsync(Employee emp);
    }
}
