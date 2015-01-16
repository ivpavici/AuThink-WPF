using System.Collections.Generic;
using System.Linq;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Model
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
