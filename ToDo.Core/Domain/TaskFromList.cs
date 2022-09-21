using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Domain
{
    public class TaskFromList : Entity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime Created { get; protected set; }
        public Guid ListOfTasksId { get; protected set; }
        public bool Completed { get; protected set; }
        private TaskFromList()
        {

        }

        public TaskFromList(Guid id, Guid listOfTasksId, string name, string description, bool completed)
        {
            Id = id;
            ListOfTasksId = listOfTasksId;
            SetName(name);
            SetDescription(description);
            Created = DateTime.UtcNow;
            SetCompleted(completed);
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

        public void SetCompleted(bool completed)
        {
            Completed = completed;
        }

    }
}
