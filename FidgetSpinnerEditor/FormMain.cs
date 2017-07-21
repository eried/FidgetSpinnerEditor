using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FidgetSpinnerEditor
{
    public partial class FormMain : Form
    {
        private const int LedRows = 16, LedColumns = 120;
        private int LedSize;
        private BitArray _bits = new BitArray(LedRows * LedColumns);
        private Rectangle drawingArea;
        private PointF center;
        private RectangleF innerDrawingArea;

        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBoxEditor_Paint(object sender, PaintEventArgs e)
        {
            var m = Math.Min(pictureBoxEditor.DisplayRectangle.Height, pictureBoxEditor.DisplayRectangle.Width)-2;
            LedSize = m / 80;
            drawingArea = new Rectangle(0, 0, m, m);
            center = new PointF(drawingArea.Left + drawingArea.Width / 2, drawingArea.Top + drawingArea.Height / 2);
            var mInner = m / 3;
            innerDrawingArea = new RectangleF(center.X - mInner / 2, center.Y - mInner / 2, mInner, mInner);

            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(Brushes.White, pictureBoxEditor.DisplayRectangle);
            e.Graphics.FillEllipse(Brushes.Yellow, drawingArea);
            e.Graphics.DrawEllipse(Pens.Black, drawingArea);
            
            e.Graphics.FillEllipse(Brushes.White, innerDrawingArea);
            e.Graphics.DrawEllipse(Pens.Black, innerDrawingArea);

            for (int i = 0; i < LedRows; i++)
            {
                var p = new PointF(center.X, ((drawingArea.Height - innerDrawingArea.Height) / 2) / (LedRows + 1) * (1+i));

                for (int j = 0; j < LedColumns; j++)
                {
                    e.Graphics.FillEllipse(GetBit(i+j*LedRows)?Brushes.Blue:Brushes.LightYellow, p.X - LedSize/2, p.Y - LedSize/2, LedSize, LedSize);
                    p = RotatePoint(p, center, 360 / LedColumns);
                }
            }
        }

        private void LoadBin(string path)
        {
            _bits = new BitArray((File.ReadAllBytes(path)).SelectMany(GetBits).ToArray());
        }

        private static IEnumerable<bool> GetBits(byte b)
        {
            for (var i = 0; i < 8; i++)
            {
                yield return (b & 0x80) != 0;
                b *= 2;
            }
        }

        private bool GetBit(int bit)
        {
            if (_bits != null && _bits.Length > bit)
                return _bits[bit];
            return false;
        }

        private static PointF RotatePoint(PointF pointToRotate, PointF centerPoint, double angleInDegrees)
        {
            var angleInRadians = angleInDegrees * (Math.PI / 180);
            var cosTheta = Math.Cos(angleInRadians);
            var sinTheta = Math.Sin(angleInRadians);

            return new PointF
            {
                X =
                    (float) (cosTheta * (pointToRotate.X - centerPoint.X) -
                             sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (float) (sinTheta * (pointToRotate.X - centerPoint.X) +
                             cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            pictureBoxEditor.Invalidate();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogBin.ShowDialog() == DialogResult.OK)
            {
                LoadBin(openFileDialogBin.FileName);
                pictureBoxEditor.Invalidate();
            }
        }

        private void pictureBoxEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.None)
            {
                var p = GetBitByPosition(e.Location);

                if (p == -1)
                    return;

                var v = e.Button == MouseButtons.Left;

                if (_bits[p] != v)
                {
                    _bits[p] = v;
                    pictureBoxEditor.Invalidate();
                }
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programmed by Erwin Ried", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetBitByPosition(Point point)
        {
            if (!drawingArea.IsEmpty && !innerDrawingArea.IsEmpty && !center.IsEmpty)
                for (var i = 0; i < LedRows; i++)
                {
                    var p = new PointF(center.X,
                        ((drawingArea.Height - innerDrawingArea.Height) / 2) / (LedRows + 1) * (1 + i));

                    for (var j = 0; j < LedColumns; j++)
                    {
                        if (new RectangleF(p.X - LedSize / 2, p.Y - LedSize / 2, LedSize, LedSize).Contains(point))
                            return (i + j * LedRows);
                        p = RotatePoint(p, center, 360 / LedColumns);
                    }
                }

            return -1;
        }
    }
}
