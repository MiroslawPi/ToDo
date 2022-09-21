using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Domain;
using ToDo.Core.Repositories;
using ToDo.Infastructure.Dto;

namespace ToDo.Infastructure.Services
{
    public class ListOfTasksService : IListOfTasksService
    {
        private readonly IListOfTasksRepository _listOfTasksRepository;
        private readonly IMapper _mapper;

        public ListOfTasksService(IListOfTasksRepository listOfTasksRepository, IMapper mapper)
        {
            _listOfTasksRepository = listOfTasksRepository;
            _mapper = mapper;
        }
        public async Task<ListOfTasksDto> GetAsync(Guid id)
        {
            var listOfTask = await _listOfTasksRepository.GetAsync(id);

            return _mapper.Map<ListOfTasksDto>(listOfTask);
        }

        public async Task<IEnumerable<ListOfTasksDto>> BrowseAsync(string name = "")
        {
            var listsOfTask = await _listOfTasksRepository.BrowseAsync(name);


            return _mapper.Map<IEnumerable<ListOfTasksDto>>(listsOfTask);

        }
        public async Task CreateAsync(Guid id, string name, string description)
        {
            var listOfTask = new ListOfTasks(id, name, description);
            await _listOfTasksRepository.AddAsync(listOfTask);

        }
        //public async Task AddTaskAsync(Guid listId, string taskName, string taskDescription)
        //{
        //    var listOfTask = await _listOfTasksRepository.GetAsync(listId);
        //    listOfTask.AddTask(taskName, taskDescription);
        //}

        public async Task UpdateAsync(Guid id, string name, string description)
        {
            var listOfTask = await _listOfTasksRepository.GetAsync(id);
            listOfTask.SetName(name);
            listOfTask.SetDescription(description);
            await _listOfTasksRepository.UpdateAsync(listOfTask);
        }

        public async Task DeleteAsync(Guid listId)
        {
            var listOfTask = await _listOfTasksRepository.GetAsync(listId);
            await _listOfTasksRepository.DeleteAsync(listOfTask);
        }


    }
}
