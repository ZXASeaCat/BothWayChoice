using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UI
{
    public class TestButton : System.Windows.Forms.Button
    {
        public TestButton()
        {
            int radius = 10;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle arcRect = new Rectangle(rect.Location, new Size(radius, radius));

            path.AddArc(arcRect, 180, 90);//左上角
            arcRect.X = rect.Right - radius;//右上角
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - radius;// 右下角
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;// 左下角
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            this.Region = new Region(path);
        }
    }
}
