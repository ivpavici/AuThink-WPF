using System.Collections.Generic;
using System.Linq;

using AuThink.Desktop.Model.Entities;

namespace AuThink.Desktop.Model.Model.Implementation
{
    public class PictureQueries: IPictureQueries
    {
        public PictureQueries
        (
            ITaskQueries taskProvider
        )
        {
            this.taskprovider = taskProvider;
        }

        private readonly ITaskQueries taskprovider;

        public IEnumerable<Picture> GetAllPicturesForTask(int taskId)
        {
            return
                taskprovider.GetSingleById(taskId)
                            .Pictures
                            .ToList();
        }
    }
}
