using System.Collections.Generic;
using System.Linq;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Model
{
    public class PictureQueries: IPictureQueries
    {
        private readonly ITaskQueries _taskprovider;

        public PictureQueries
        (
            ITaskQueries taskProvider
        )
        {
            _taskprovider = taskProvider;
        }

        public IEnumerable<Picture> GetAllPicturesForTask(int taskId)
        {
            return
                _taskprovider.GetSingleById(taskId)
                            .Pictures
                            .ToList();
        }
    }
}
