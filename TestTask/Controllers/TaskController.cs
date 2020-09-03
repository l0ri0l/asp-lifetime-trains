using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        

        public TaskController(ILogger<TaskController> logger)
        {
            
        }

        [HttpGet]
        public void Get()
        {
            
        }
    }
}
