using System.Collections.Generic;

namespace AuThink.Desktop.Model.Entities
{
    public class Task
    {
        public Task
        (
            int id,
            string name,
            string description,
            string thumbUrl,
            string type,
            int difficulty,

            IEnumerable<Picture> pictures,
            Sound voiceCommand = null
        )
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.ThumbUrl = thumbUrl;
            this.Type = type;
            this.Difficulty = difficulty;

            this.Pictures = pictures;
            this.VoiceCommand = voiceCommand;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ThumbUrl { get; private set; }
        public string Type { get; private set; }
        public int Difficulty { get; private set; }

        public IEnumerable<Picture> Pictures { get; private set; }
        public Sound VoiceCommand { get; private set; }
    }
}
