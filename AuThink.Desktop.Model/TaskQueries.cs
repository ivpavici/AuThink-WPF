using System.Collections.Generic;
using System.Linq;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Model
{
    public class TaskQueries: ITaskQueries
    {
        public TaskQueries
        (
            IDataProvider dataProvider
        )
        {
            this.dataProvider = dataProvider;
        }

        private readonly IDataProvider dataProvider;

        public IEnumerable<Task> GetAllTasksForTest(int testId)
        {
            var a =
                dataProvider.GetAll()
                            .Single(test => test.Id == testId)
                            .Tasks
                            .ToList();

            return a;
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
