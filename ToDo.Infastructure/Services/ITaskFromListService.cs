using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Infastructure.Dto;

namespace ToDo.Infastructure.Services
{
    public interface ITaskFromListService
    {
        Task<TaskFromList> GetAsync(Guid id);
        Task<IEnumerable<TaskFromList>> BrowseAsync(string name = "");
        Task CreateAsync(Guid id, Guid listid, string name, string description, bool completed);
        Task UpdateAsync(Guid id, string name, string description, bool completed);
        //Task DeleteAsync(Guid id, Guid listId);
        Task DeleteAsync(Guid id);
    }
}
