using AutoMapper;
using KanbanFlow.API.Models.DTOs.Task;
using KanbanFlow.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KanbanFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskAddDto newTaskDto)
        {
            var taskdomain = _mapper.Map<Models.Domain.Task>(newTaskDto);
            taskdomain = await _taskRepository.CreateTask(taskdomain);
            var taskDto = _mapper.Map<TaskDto>(taskdomain);
            return Ok(taskDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasksDomain = await _taskRepository.GetAllTasks();
            if (!tasksDomain.Any())
                return NotFound();

            var tasksDto = _mapper.Map<List<TaskDto>>(tasksDomain);
            return Ok(tasksDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var taskDomain = await _taskRepository.GetTask(id);
            if (taskDomain == null)
                return NotFound();

            var taskDto = _mapper.Map<TaskDto>(taskDomain);
            return Ok(taskDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskEditDto taskEditDto)
        {
            var taskDomain = _mapper.Map<Models.Domain.Task>(taskEditDto);
            taskDomain = await _taskRepository.UpdateTask(id, taskDomain);
            if (taskDomain == null)
                return NotFound();

            var taskDto = _mapper.Map<TaskDto>(taskDomain);
            return Ok(taskDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var taskDomain = await _taskRepository.DeleteTask(id);
            if (taskDomain == null)
                return NotFound();

            var taskDto = _mapper.Map<TaskDto>(taskDomain);
            return Ok(taskDto);
        }
    }
}
