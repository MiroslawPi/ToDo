using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;

namespace ToDo.Infastructure.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ListOfTasks> ListOfTasks { get; set; }
        public DbSet<TaskFromList> TaskFromList { get; set; }
    }
}
