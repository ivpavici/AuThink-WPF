using System.Collections.Generic;
using System.Linq;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Model
{
    public class TaskQueries: ITaskQueries
    {
        private readonly IDataProvider _dataProvider;

        public TaskQueries
        (
            IDataProvider dataProvider
        )
        {
            _dataProvider = dataProvider;
        }

        public IEnumerable<Task> GetAllTasksForTest(int testId)
        {
            return 
                _dataProvider
                    .GetAll()
                    .Single(test => test.Id == testId)
                    .Tasks
                    .ToList();
        }
        
        public Task GetSingleById(int taskId)
        {
            var test = _dataProvider.GetAll()
                .SingleOrDefault(t => t.Tasks.Any(task => task.Id == taskId));

            if (test != null)
            {
                return
                    test
                        .Tasks
                        .Single(task => task.Id == taskId);
            }

            return null;
        }
    }
}
