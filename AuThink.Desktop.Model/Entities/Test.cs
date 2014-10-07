using System.Collections.Generic;

namespace AuThink.Desktop.Model.Entities
{
    public class Test
    {
        public Test
        (
            int id,
            string name,
            string description,

            List<Task> tasks
        )
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;

            this.Tasks = tasks;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public List<Task> Tasks { get; private set; }
    }
}
