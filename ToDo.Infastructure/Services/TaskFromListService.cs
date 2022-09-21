using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Core.Repositories;
using ToDo.Infastructure.Commands;
using ToDo.Infastructure.Dto;
using ToDo.Infastructure.Repositories;

namespace ToDo.Infastructure.Services
{
    public class TaskFromListService : ITaskFromListService
    {
        private readonly ITaskFromListRepository _taskFromListRepository;
        private readonly IListOfTasksRepository _listOfTasksRepository;
        private readonly IMapper _mapper;

        public TaskFromListService(ITaskFromListRepository taskFromListRepository, IMapper mapper, IListOfTasksRepository listOfTasksRepository)
        {
            _taskFromListRepository = taskFromListRepository;
            _mapper = mapper;
            _listOfTasksRepository = listOfTasksRepository;
        }
        public async Task<TaskFromList> GetAsync(Guid id)
        {
            var taskFromList = await _taskFromListRepository.GetAsync(id);

            return _mapper.Map<TaskFromList>(taskFromList);
        }

        public async Task<IEnumerable<TaskFromList>> BrowseAsync(string name = "")
        {
            var taskFromList = await _taskFromListRepository.BrowseAsync(name);

            return _mapper.Map<IEnumerable<TaskFromList>>(taskFromList);

        }
        public async Task CreateAsync(Guid id, Guid listId, string name, string description, bool completed)
        {
            var taskFromList = new TaskFromList(id, listId, name, description, completed);
            await _taskFromListRepository.AddAsync(taskFromList);
            await _listOfTasksRepository.AddTaskAsync(taskFromList);
        }

        public async Task UpdateAsync(Guid id, string name, string description, bool completed)
        {
            var taskFromList = await _taskFromListRepository.GetAsync(id);
            taskFromList.SetName(name);
            taskFromList.SetDescription(description);
            taskFromList.SetCompleted(completed);
            await _taskFromListRepository.UpdateAsync(taskFromList);
        }

        //public async Task DeleteAsync(Guid id, Guid listId)
        //{
        //    var listOfTasks = await _listOfTasksRepository.GetAsync(listId);
        //    var taskFromList = await _taskFromListRepository.GetAsync(id);
        //    listOfTasks.RemoveTask(taskFromList);
        //    _taskFromListRepository.DeleteAsync(taskFromList);
        //}

        public async Task DeleteAsync(Guid id)
        {
            var taskFromList = await _taskFromListRepository.GetAsync(id);
            await _taskFromListRepository.DeleteAsync(taskFromList);
        }


    }
}
