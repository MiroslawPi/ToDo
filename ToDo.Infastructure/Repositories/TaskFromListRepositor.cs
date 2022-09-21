using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Core.Repositories;
using ToDo.Infastructure.Data;

namespace ToDo.Infastructure.Repositories
{
    public class TaskFromListRepositor : ITaskFromListRepository
    {
        //private static readonly ISet<TaskFromList> _taskFromList = new HashSet<TaskFromList> 
        //{ 

        //};

        //protected ToDoContext _ctx;
        //public TaskFromListRepositor(ToDoContext ctx)
        //{
        //    _ctx = ctx;
        //}

        private readonly ToDoContext _ctx = new ToDoContext();

        public async Task<TaskFromList> GetAsync(Guid id)
        {
            //return await Task.FromResult(_taskFromList.SingleOrDefault(x => x.Id == id));
            return await _ctx.TaskFromList.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TaskFromList>> BrowseAsync(string name = "")
        {
            //var taskFromList = _taskFromList.AsEnumerable();

            var taskFromList = _ctx.TaskFromList.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                taskFromList = taskFromList.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(taskFromList);

        }
        public async Task AddAsync(TaskFromList taskFromList)
        {
            //_taskFromList.Add(taskFromList);
            _ctx.TaskFromList.Add(taskFromList);
            await _ctx.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(TaskFromList taskFromList)
        {
            //_taskFromList.Add(taskFromList);
            await _ctx.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(TaskFromList taskFromList)
        {
            //_taskFromList.Remove(taskFromList);
            _ctx.TaskFromList.Remove(taskFromList);
            await _ctx.SaveChangesAsync();

            await Task.CompletedTask;
        }


    }
}
