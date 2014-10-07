using System.Collections.Generic;

using AuThink.Desktop.Model.Entities;

namespace AuThink.Desktop.Model.Data
{
    public interface IDataProvider
    {
        IEnumerable<Test> GetAll();
        IEnumerable<Child> GetAllChildren();
    }
}
