using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Enums
{
    public enum TaskState
    {
        created = 0,
        running = 1,
        finished = 2,
        crashed = 3 // на случай ошибки в записи
    }
}
