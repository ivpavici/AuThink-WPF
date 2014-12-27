using System.Collections.Generic;

using AuThink.Desktop.Model.Entities;

namespace AuThink.Desktop.Model.Model
{
    public interface IPictureQueries
    {
        IEnumerable<Picture> GetAllPicturesForTask(int taskId);
    }
}
