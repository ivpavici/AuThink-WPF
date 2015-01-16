namespace AuThink.Desktop.Core.Entities
{
    public class Color
    {
        public Color
        (
           int id,
           string value,
           bool isCorrect,
           int pictureId
        )
        {
            this.Id = id;
            this.Value = value;
            this.IsCorrect = isCorrect;
            this.PictureId = pictureId;
        }
        public int Id { get; private set; }
        public string Value { get; private set; }
        public bool IsCorrect { get; private set; }
        public int PictureId { get; private set; }
    }
}
