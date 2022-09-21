using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Core.Repositories;
using ToDo.Infastructure.Data;
using ToDo.Infastructure.Dto;

namespace ToDo.Infastructure.Repositories
{
    
    public class ListOfTasksRepository : IListOfTasksRepository
    {
        //private static readonly ISet<ListOfTasks> _listsOfTasks = new HashSet<ListOfTasks> 
        //{ 
        //    new ListOfTasks(Guid.NewGuid(), "List 1", "Description 1"),
        //    new ListOfTasks(Guid.NewGuid(), "List 2", "Description 2"),
        //    new ListOfTasks(Guid.NewGuid(), "List 3", "Description 3")
        //};

        private readonly ToDoContext _ctx = new ToDoContext();
        //private readonly IMapper _mapper;

        //protected ToDoContext _ctx;
        //public ListOfTasksRepository(ToDoContext ctx)
        //{
        //    _ctx = ctx;
        //}

        //public ListOfTasksRepository(IMapper mapper, ToDoContext ctx)
        //{
        //    _mapper = mapper;
        //    _ctx = ctx;
        //}

        //protected ToDoContext _ctx;
        //public ListOfTasksRepository(ToDoContext ctx)
        //{
        //    _ctx = ctx;
        //}

        public async Task<ListOfTasks> GetAsync(Guid id)
        {
            return await _ctx.ListOfTasks.SingleOrDefaultAsync(x => x.Id == id);
            //return await Task.FromResult(_listsOfTasks.SingleOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<ListOfTasks>> BrowseAsync(string name = "")
        {
            //var listOfTasks = _listsOfTasks.AsEnumerable();
            var listOfTasks = _ctx.ListOfTasks.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                listOfTasks = listOfTasks.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }
            var taskFromList = _ctx.TaskFromList.AsEnumerable();

            //IEnumerable<ListOfTasksDto> listOfTasksModel = listOfTasks.GroupJoin(taskFromList, l => l.Id, t => t.ListOfTasksId,
            //    (list, taskGroup) => new ListOfTasksDto
            //    {
            //        Id = list.Id,
            //        Name = list.Name,
            //        Description = list.Description,
            //        Created = list.Created,
            //        _taskFromList = taskGroup.ToList()
            //    });

            //listOfTasks = _mapper.Map<IEnumerable<ListOfTasks>>(listOfTasksModel);

            //return await Task.FromResult(listOfTasks);

            listOfTasks = listOfTasks.GroupJoin(taskFromList, l => l.Id, t => t.ListOfTasksId,
                (list, taskGroup) => new ListOfTasks
                {
                    Id = list.Id,
                    Name = list.Name,
                    Description = list.Description,
                    Created = list.Created,
                    _taskFromList = taskGroup.ToList()
                });

            return await Task.FromResult(listOfTasks);

        }
        public async Task AddAsync(ListOfTasks listOfTasks)
        {
            //_listsOfTasks.Add(listOfTasks);

            _ctx.ListOfTasks.Add(listOfTasks);
            await _ctx.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task AddTaskAsync(TaskFromList taskFromList)
        {
            //var listOfTasks = _listsOfTasks.SingleOrDefault(x => x.Id == taskFromList.ListOfTasksId);
            //listOfTasks.AddTask(taskFromList);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(ListOfTasks listOfTasks)
        {
            //_listsOfTasks.Remove(listOfTasks);
            _ctx.ListOfTasks.Remove(listOfTasks);
            await _ctx.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(ListOfTasks listOfTask)
        {
            await _ctx.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
