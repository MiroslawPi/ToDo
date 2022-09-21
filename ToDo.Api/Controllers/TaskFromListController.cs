using Microsoft.AspNetCore.Mvc;
using ToDo.Infastructure.Commands;
using ToDo.Infastructure.Services;

namespace ToDo.Api.Controllers
{
    [Route("[controller]")]
    public class TaskFromListController : Controller
    {
        private readonly ITaskFromListService _taskFromListService;

        public TaskFromListController(ITaskFromListService taskFromListService)
        {
            _taskFromListService = taskFromListService;
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> Get(Guid taskId)
        {
            var taskFromList = await _taskFromListService.GetAsync(taskId);
            if(taskFromList == null)
            {
                return NotFound();
            }
            return Json(taskFromList);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var taskFromList = await _taskFromListService.BrowseAsync(name);
            if (taskFromList == null)
            {
                return NotFound();
            }
            return Json(taskFromList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTask createTask)
        {
            createTask.Id = Guid.NewGuid();
            await _taskFromListService.CreateAsync(createTask.Id, createTask.ListId, createTask.Name, createTask.Description, createTask.Completed);

            return Created($"/listOfTasks/{createTask.Id}", null);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CreateTask createTask)
        {
            await _taskFromListService.UpdateAsync(createTask.Id, createTask.Name, createTask.Description, createTask.Completed);

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTask delteTask)
        {
            //await _taskFromListService.DeleteAsync(delteTask.Id, delteTask.ListId);
            await _taskFromListService.DeleteAsync(delteTask.Id);

            return NoContent();
        }

    }
}
