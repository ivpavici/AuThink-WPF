using System.Collections.Generic;

using AuThink.Desktop.Model.Entities;

namespace AuThink.Desktop.Model.Model
{
    public interface ITaskQueries
    {
        List<Task> GetAllTasksForTest(int testId);
        
        Task GetSingleById(int taskid);
    }
}
