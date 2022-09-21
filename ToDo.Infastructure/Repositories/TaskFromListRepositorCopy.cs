using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Core.Repositories;

namespace ToDo.Infastructure.Repositories
{
    public class TaskFromListRepositorCopy : ITaskFromListRepository
    {
        private static readonly ISet<TaskFromList> _taskFromList = new HashSet<TaskFromList> 
        { 

        };

        public async Task<TaskFromList> GetAsync(Guid id)
        {
            return await Task.FromResult(_taskFromList.SingleOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<TaskFromList>> BrowseAsync(string name = "")
        {
            var taskFromList = _taskFromList.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                taskFromList = taskFromList.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(taskFromList);
        }
        public async Task AddAsync(TaskFromList taskFromList)
        {
            _taskFromList.Add(taskFromList);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(TaskFromList taskFromList)
        {
            _taskFromList.Remove(taskFromList);

            await Task.CompletedTask;
        }

        public Task UpdateAsync(TaskFromList taskFromList)
        {
            throw new NotImplementedException();
        }
    }
}
