using System;
using System.Collections.Generic;
using System.IO;

namespace AuThink.Desktop.Core.Entities
{
    public abstract class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public class BasicDetails : Picture
        {
            public BasicDetails
            (
                int id,
                string url
            )
            {
                this.Id = id;
                this.Url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, url);
            }
        }

        public class AnswerPicture : Picture
        {
            public AnswerPicture() { }
            public AnswerPicture
            (
                int id,
                string url,
                Sound sound,
                bool isAnswer
             )
            {
                this.Id = id;
                this.Url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, url);
                this.Sound = sound;
                this.IsAnswer = isAnswer;
            }
            public Sound Sound { get; private set; }
            public bool IsAnswer { get; set; }
        }

        public class ColorPicture : Picture
        {
            public ColorPicture
            (
                int id,
                string url,
                Sound sound,
                List<Color> colors
             )
            {
                this.Id = id;
                this.Url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, url);
                this.Sound = sound;
                this.Colors = colors;
            }
            public Sound Sound { get; private set; }
            public List<Color> Colors { get; private set; }
        }

        public class PairHalfPicture : Picture
        {
            public PairHalfPicture
            (
                int id,
                string url,
                string uniquepairid,
                bool isLeftHalf
            )
            {
                this.Id = id;
                this.Url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, url);
                this.UniquePairId = uniquepairid;
                this.IsLeftHalf = isLeftHalf;
            }
            public string UniquePairId { get; private set; }
            public bool IsLeftHalf { get; private set; }
        }

    }
}
