using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;

namespace ToDo.Core.Repositories
{
    public interface IListOfTasksRepository
    {

        Task<ListOfTasks> GetAsync(Guid id);
        Task<IEnumerable<ListOfTasks>> BrowseAsync(string name = "");
        Task AddAsync(ListOfTasks list);
        Task AddTaskAsync(TaskFromList taskFromList);
        Task DeleteAsync(ListOfTasks list);
        Task UpdateAsync(ListOfTasks listOfTask);
    }
}
