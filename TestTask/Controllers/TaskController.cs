using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTask.Abstractions;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [Route("task/{id}")]
        public void GetTask(Guid id)
        {
            
        }
    }
}
