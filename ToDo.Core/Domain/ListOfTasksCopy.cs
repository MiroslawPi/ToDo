using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Domain
{

    public class ListOfTasksCopy : Entity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime Created { get; protected set; }

        private ISet<TaskFromList> _taskFromList = new HashSet<TaskFromList>();

        public IEnumerable<TaskFromList> TasksFromList => _taskFromList;

        private ListOfTasksCopy()
        {

        }

        public ListOfTasksCopy(Guid id, string name, string description)
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
