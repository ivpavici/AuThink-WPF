using System.Collections.Generic;

using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Core
{
    public interface ITestQueries
    {
        IEnumerable<Test> GetAll();
    }
}
