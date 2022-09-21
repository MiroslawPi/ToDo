using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Core.Repositories;

namespace ToDo.Infastructure.Repositories
{
    public class ListOfTasksRepositoryCopy : IListOfTasksRepository
    {
        private static readonly ISet<ListOfTasks> _listsOfTasks = new HashSet<ListOfTasks> 
        { 
            new ListOfTasks(Guid.NewGuid(), "List 1", "Description 1"),
            new ListOfTasks(Guid.NewGuid(), "List 2", "Description 2"),
            new ListOfTasks(Guid.NewGuid(), "List 3", "Description 3")
        };

        public async Task<ListOfTasks> GetAsync(Guid id)
        {
            return await Task.FromResult(_listsOfTasks.SingleOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<ListOfTasks>> BrowseAsync(string name = "")
        {
            var listOfTasks = _listsOfTasks.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                listOfTasks = listOfTasks.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
                listOfTasks = listOfTasks.OrderBy(x => x.TasksFromList.OrderBy(x => x.Completed));
            }

            return await Task.FromResult(listOfTasks);
        }
        public async Task AddAsync(ListOfTasks listOfTasks)
        {
            _listsOfTasks.Add(listOfTasks);

            await Task.CompletedTask;
        }

        public async Task AddTaskAsync(TaskFromList taskFromList)
        {
            var listOfTasks = _listsOfTasks.SingleOrDefault(x => x.Id == taskFromList.ListOfTasksId);
            listOfTasks.AddTask(taskFromList);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(ListOfTasks listOfTasks)
        {
            _listsOfTasks.Remove(listOfTasks);

            await Task.CompletedTask;
        }

        public Task UpdateAsync(ListOfTasks listOfTask)
        {
            throw new NotImplementedException();
        }
    }
}
