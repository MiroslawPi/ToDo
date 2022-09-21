using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Domain
{

    public class ListOfTasks : Entity
    {
        //public string Name { get; protected set; }
        //public string Description { get; protected set; }
        //public DateTime Created { get; protected set; }

        //private ISet<TaskFromList> _taskFromList = new HashSet<TaskFromList>();

        //public List<TaskFromList> _taskFromList { get; protected set; }

        //private ListOfTasks()
        //{

        //}

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<TaskFromList> _taskFromList { get; set; }

        public IEnumerable<TaskFromList> TasksFromList => _taskFromList;

        public ListOfTasks()
        {

        }
        public ListOfTasks(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = DateTime.UtcNow;
        }

        public void AddTask(TaskFromList taskFromList)
        {
            _taskFromList.Add(taskFromList);
        }

        public void RemoveTask(TaskFromList taskFromList)
        {
            _taskFromList.Remove(taskFromList);
        }

        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = name;
            }           
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
