using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class TrapezoidButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddPolygon(new Point[] {
            new Point(Width / 4, 0),
            new Point(3 * Width / 4, 0),
            new Point(Width, Height),
            new Point(0, Height)
        });

        this.Region = new Region(path);

        base.OnPaint(pevent);
    }
}
