namespace AuThink.Desktop.Model.Entities
{
    public class Sound
    {
        public Sound
        (
            int id,
            string url,
            string type
        )
        {
            this.Id = id;
            this.Url = url;
            this.Type = type;
        }

        public int Id { get; private set; }
        public string Url { get; private set; }
        public string Type { get; private set; }
    }
}
