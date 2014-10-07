using System.Collections.Generic;
using System.Linq;

using AuThink.Desktop.Model.Data;
using AuThink.Desktop.Model.Entities;

namespace AuThink.Desktop.Model.Model.Implementation
{
    public class TaskQueries
    {
        public TaskQueries
        (
            IDataProvider dataProvider
        )
        {
            this.dataProvider = dataProvider;
        }

        private readonly IDataProvider dataProvider;

        public List<Task> GetAllTasksForTest(int testId)
        {
            return
                dataProvider.GetAll()
                            .Single(test => test.Id == testId)
                            .Tasks
                            .ToList();
        }
        
        public Task GetSingleById(int taskId)
        {
            var test = dataProvider.GetAll()
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
