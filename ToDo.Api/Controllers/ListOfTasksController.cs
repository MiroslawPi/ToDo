using Microsoft.AspNetCore.Mvc;
using ToDo.Infastructure.Commands;
using ToDo.Infastructure.Services;

namespace ToDo.Api.Controllers
{
    [Route("[controller]")]
    public class ListOfTasksController : Controller
    {
        private readonly IListOfTasksService _listOfTasksService;

        public ListOfTasksController(IListOfTasksService listOfTasksService)
        {
             _listOfTasksService = listOfTasksService;
        }

        [HttpGet("{listId}")]
        public async Task<IActionResult> Get(Guid listId)
        {
            var listOfTask = await _listOfTasksService.GetAsync(listId);
            if(listOfTask == null)
            {
                return NotFound();
            }
            return Json(listOfTask);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var listsOfTask = await _listOfTasksService.BrowseAsync(name);
            if (listsOfTask == null)
            {
                return NotFound();
            }
            return Json(listsOfTask);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateListOfTask listOfTask)
        {
            listOfTask.Id = Guid.NewGuid();
            await _listOfTasksService.CreateAsync(listOfTask.Id, listOfTask.Name, listOfTask.Description);

            return Created($"/listOfTasks/{listOfTask.Id}", null);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CreateListOfTask listOfTask)
        {
            await _listOfTasksService.UpdateAsync(listOfTask.Id, listOfTask.Name, listOfTask.Description);

            return NoContent();

        }

        [HttpDelete("{listId}")]
        public async Task<IActionResult> Delete(Guid listId)
        {
            await _listOfTasksService.DeleteAsync(listId);

            return NoContent();
        }
    }
}
