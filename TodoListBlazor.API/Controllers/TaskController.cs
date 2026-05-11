using Microsoft.AspNetCore.Mvc;
using TodoListBlazor.API.Repositories;
using TodoTask = TodoListBlazor.API.Entities.Task;

namespace TodoListBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetTaskList();
            return Ok(tasks);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TodoTask>> GetTaskById(Guid id)
        {
            var task = await _taskRepository.GetById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TodoTask>> CreateTask([FromBody] TodoTask task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (task.Id == Guid.Empty)
            {
                task.Id = Guid.NewGuid();
            }

            if (task.CreateDate == default)
            {
                task.CreateDate = DateTime.UtcNow;
            }

            var createdTask = await _taskRepository.Create(task);

            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TodoTask>> UpdateTask(Guid id, [FromBody] TodoTask task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest("Route id does not match task id.");
            }

            var existingTask = await _taskRepository.GetById(id);

            if (existingTask == null)
            {
                return NotFound();
            }

            var updatedTask = await _taskRepository.Update(task);

            return Ok(updatedTask);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var existingTask = await _taskRepository.GetById(id);

            if (existingTask == null)
            {
                return NotFound();
            }

            await _taskRepository.Delete(existingTask);

            return NoContent();
        }
    }
}
