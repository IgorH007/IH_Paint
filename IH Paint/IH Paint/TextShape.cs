using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Paint
{
    [Serializable]
    public class TextShape : Shape
    {
        public string Text { get; set; } = "Text";
        public Font TextFont { get; set; } = new Font("Arial", 12);

        public TextShape(Point location, string text, Font font, Color color)
            : base(location, color, 1f) 
        {
            Text = text;
            TextFont = font;
        }

        public TextShape() : base() { } 

        public override void Draw(Graphics g)
        {
            if (string.IsNullOrEmpty(Text) || TextFont == null) return;

            using (Brush brush = new SolidBrush(DrawColor))
            {
                g.DrawString(Text, TextFont, brush, Location);
            }
        }

        public override Rectangle GetBounds()
        {
            if (string.IsNullOrEmpty(Text) || TextFont == null)
                return new Rectangle(Location, new Size(10, 10)); 
            SizeF size;
            using (Bitmap tempBmp = new Bitmap(1, 1))
            using (Graphics tempG = Graphics.FromImage(tempBmp))
            {
                size = tempG.MeasureString(Text, TextFont);
            }
            return new Rectangle(Location, Size.Ceiling(size));
        }

        public override Shape Clone()
        {
            return new TextShape(this.Location, this.Text, (Font)this.TextFont.Clone(), this.DrawColor);
        }
    }
}
