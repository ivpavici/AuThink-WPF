using System.Collections.Generic;

using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Core
{
    public interface ITaskQueries
    {
        IEnumerable<Task> GetAllTasksForTest(int testId);
        
        Task GetSingleById(int taskid);
    }
}
