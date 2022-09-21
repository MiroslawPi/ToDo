using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Infastructure.Dto;

namespace ToDo.Infastructure.Services
{
    public interface IListOfTasksService
    {
        Task<ListOfTasksDto> GetAsync(Guid id);
        Task<IEnumerable<ListOfTasksDto>> BrowseAsync(string name = "");
        Task CreateAsync(Guid id, string name, string description);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, string name, string description);
    }
}
