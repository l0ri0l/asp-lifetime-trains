using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Abstractions;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskDataBaseReadService _taskDataBaseReadService;
        private readonly ITaskDataBaseWriteService _taskDataBaseWriteService;
        public TaskController(ITaskDataBaseReadService taskDataBaseReadService, ITaskDataBaseWriteService taskDataBaseWriteService)
        {
            _taskDataBaseReadService = taskDataBaseReadService;
            _taskDataBaseWriteService = taskDataBaseWriteService;
        }

        [HttpGet]
        [Route("{sendedGuid}")] // Метод поиска задачи
        public async Task<IActionResult> GetTask(string sendedGuid)
        {
            Guid taskGuid;
            var isGuid = Guid.TryParse(sendedGuid, out taskGuid);
            if (isGuid)
            {
                var taskModel = await _taskDataBaseReadService.FindTask(taskGuid);

                if (taskModel == null)
                    return StatusCode(404, "Задача не найдена");

                return StatusCode(200, $"статус: {taskModel.Status}, время обновления задачи: {taskModel.TimeStamp:yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz}");
            }
            return StatusCode(400, "Ошибка переданного GUID задачи");
        }

        [HttpPost] // Создание и обновление задачи
        public async Task<IActionResult> CreateTask(string uselessKey) //просто потому что post не может принимать пустое тело. 
        {
            var taskModel = await _taskDataBaseWriteService.CreateTask();

            // Для фонового выполнения можно было бы использовать Hangfire но задача маленькая, и этот метод можно добавить в расширении
            _taskDataBaseWriteService.UpdateTask(taskModel); //await нужен только внутри метода для обновления статуса задания, мы просто возвращаем клиенту Guid созданной задачи
           
            return StatusCode(202, taskModel.Id);
        }

    }
}
