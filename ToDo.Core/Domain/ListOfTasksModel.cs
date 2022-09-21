using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Domain
{

    public class ListOfTasksModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        //private ISet<TaskFromList> _taskFromList = new HashSet<TaskFromList>();

        //public List<TaskFromList> _taskFromList = new List<TaskFromList>();

        public List<TaskFromList> _taskFromList { get; set; }



    }
}
