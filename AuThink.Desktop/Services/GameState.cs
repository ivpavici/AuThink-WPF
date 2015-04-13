using System.Collections.Generic;
using System.Linq;

namespace AuThink.Desktop.Services
{
    public static class GameState
    {
        public static List<int> TaskIds;
        public static int CurrentTestId;

        public static void Start(int testId, List<int> taskIds)
        {
            CurrentTestId = testId;
            TaskIds = taskIds;
        }

        public static int GetTask()
        {
            return TaskIds.First();
        }

        public static void EndTask()
        {
            TaskIds.Remove(TaskIds.First());
        }
    }
}
