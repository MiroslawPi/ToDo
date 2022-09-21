using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;

namespace ToDo.Core.Repositories
{
    public interface ITaskFromListRepository
    {
        Task<TaskFromList> GetAsync(Guid id);
        Task<IEnumerable<TaskFromList>> BrowseAsync(string name = "");
        Task AddAsync(TaskFromList list);
        Task UpdateAsync(TaskFromList taskFromList);
        Task DeleteAsync(TaskFromList list);
    }
}
