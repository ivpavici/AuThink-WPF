using System.Collections.Generic;

using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Core
{
    public interface IPictureQueries
    {
        IEnumerable<Picture> GetAllPicturesForTask(int taskId);
    }
}
