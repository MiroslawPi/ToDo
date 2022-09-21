using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;

namespace ToDo.Infastructure.Dto
{
    public class ListOfTasksDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<TaskFromListDto> TasksFromList { get; set; }
    }
}
