using System.Collections.Generic;

using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Core
{
    public interface IDataProvider
    {
        IEnumerable<Test> GetAll();
        IEnumerable<Child> GetAllChildren();
    }
}
