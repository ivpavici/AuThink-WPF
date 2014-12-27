using System.Collections.Generic;
using System.Linq;

using AuThink.Desktop.Model.Data;
using AuThink.Desktop.Model.Entities;

namespace AuThink.Desktop.Model.Model.Implementation
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
