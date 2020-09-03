using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTask.Abstractions;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api")]
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
        [Route("task/{sendedGuid}")]
        public IActionResult GetTask(string sendedGuid)
        {
            Guid taskGuid;
            var tasks = _taskDataBaseReadService.GetAll().ToList();
            var isGuid = Guid.TryParse(sendedGuid, out taskGuid);
            if (isGuid)
            {
                var taskModel = _taskDataBaseReadService.FindTask(taskGuid);

                if (taskModel == null)
                    return StatusCode(404, "Задача не найдена");

                return StatusCode(200, $"статус: {taskModel.Status}, время обновления задачи: {taskModel.TimeStamp}");
            }
            return StatusCode(400, "Ошибка переданного GUID задачи");
        }

        [HttpPost]
        [Route("task")]
        public IActionResult CreateTask()
        {
            var taskModel = _taskDataBaseWriteService.CreateTask();

            Task.Run(() => _taskDataBaseWriteService.TestUpdateTask(taskModel));
           
            return StatusCode(202, taskModel.Id);
        }
    }
}
