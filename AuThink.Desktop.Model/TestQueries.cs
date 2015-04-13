using System.Collections.Generic;
using System.Linq;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Model
{
    public class TestQueries: ITestQueries
    {
        private readonly IDataProvider _dataProvider;

        public TestQueries
        (
            IDataProvider dataProvider
        )
        {
            _dataProvider = dataProvider;
        }

        public IEnumerable<Test> GetAll()
        {
            return
                _dataProvider.GetAll().ToList();
        }
    }
}
