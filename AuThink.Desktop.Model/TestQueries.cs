using System.Collections.Generic;
using System.Linq;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Model
{
    public class TestQueries: ITestQueries
    {
        public TestQueries
        (
            IDataProvider dataProvider
        )
        {
            this.dataProvider = dataProvider;
        }

        private readonly IDataProvider dataProvider;

        public IEnumerable<Test> GetAll()
        {
            return
                dataProvider.GetAll().ToList();
        }
    }
}
