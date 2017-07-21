using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FidgetSpinnerEditor
{
    public partial class FormMain : Form
    {
        private const int LedRows = 16, LedColumns = 120;
        private BitArray _bits = new BitArray(LedRows * LedColumns);
        private PointF _center;
        private Rectangle _drawingArea;
        private RectangleF _innerDrawingArea;
        private int _ledSize;

        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBoxEditor_Paint(object sender, PaintEventArgs e)
        {
            var m = Math.Min(pictureBoxEditor.DisplayRectangle.Height, pictureBoxEditor.DisplayRectangle.Width) - 2;
            _ledSize = m / 67;
            _drawingArea = new Rectangle((pictureBoxEditor.DisplayRectangle.Width - m) / 2,
                (pictureBoxEditor.DisplayRectangle.Height - m) / 2, m, m);
            _center = new Point(_drawingArea.Left + _drawingArea.Width / 2, _drawingArea.Top + _drawingArea.Height / 2);
            var mInner = m / 2;
            _innerDrawingArea = new RectangleF(_center.X - mInner / 2, _center.Y - mInner / 2, mInner, mInner);

            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(Brushes.White, pictureBoxEditor.DisplayRectangle);
            e.Graphics.FillEllipse(Brushes.Yellow, _drawingArea);
            e.Graphics.DrawEllipse(Pens.Black, _drawingArea);

            e.Graphics.FillEllipse(Brushes.White, _innerDrawingArea);
            e.Graphics.DrawEllipse(Pens.Black, _innerDrawingArea);

            var yspacing = (_drawingArea.Height - _innerDrawingArea.Height) / 2 / (LedRows + 1);
            for (var i = 0; i < LedRows; i++)
            {
                var p = new PointF(_center.X,_drawingArea.Top + (yspacing * (1 + i)));

                for (var j = 0; j < LedColumns; j++)
                {
                    e.Graphics.FillEllipse(GetBit(i + j * LedRows) ? Brushes.Blue : Brushes.LightYellow,
                        p.X - _ledSize / 2, p.Y - _ledSize / 2, _ledSize, _ledSize);
                    p = RotatePoint(p, _center, 360 / LedColumns);
                }
            }
        }

        private void LoadBin(string path)
        {
            _bits = new BitArray(File.ReadAllBytes(path).SelectMany(GetBits).ToArray());
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
            if (e.Button != MouseButtons.None)
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
            MessageBox.Show("Create or edit by clicking or dragging on the spinner. Use the left mouse button to draw " +
                "and the right to clear. Copy the files from and to your phone using the folder: 'Phone\\Internal " +
                "shared storage\\HWX-SPINNER'.\n\nProgrammed by Erwin Ried.", "About", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogBin.Filter = openFileDialogBin.Filter;
            saveFileDialogBin.InitialDirectory = openFileDialogBin.FileName;

            if (saveFileDialogBin.ShowDialog() != DialogResult.OK) return;

            try
            {
                File.WriteAllBytes(saveFileDialogBin.FileName, BitArrayToByteArray(_bits));
                MessageBox.Show("File saved to: " + saveFileDialogBin.FileName, "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            var output = new List<byte>();

            for (var i = 0; i < bits.Length; i += 8)
            {
                byte b = 0;
                if (bits[i + 7]) b++;
                if (bits[i + 6]) b += 2;
                if (bits[i + 5]) b += 4;
                if (bits[i + 4]) b += 8;
                if (bits[i + 3]) b += 16;
                if (bits[i + 2]) b += 32;
                if (bits[i + 1]) b += 64;
                if (bits[i]) b += 128;
                output.Add(b);
            }
            return output.ToArray();
        }

        private int GetBitByPosition(Point point)
        {
            if (!_drawingArea.IsEmpty && !_innerDrawingArea.IsEmpty && !_center.IsEmpty)
            {
                var yspacing = (_drawingArea.Height - _innerDrawingArea.Height) / 2 / (LedRows + 1);
                for (var i = 0; i < LedRows; i++)
                {
                    var p = new PointF(_center.X, _drawingArea.Top + (yspacing * (1 + i)));

                    for (var j = 0; j < LedColumns; j++)
                    {
                        if (new RectangleF(p.X - _ledSize / 2, p.Y - _ledSize / 2, _ledSize, _ledSize).Contains(point))
                            return i + j * LedRows;
                        p = RotatePoint(p, _center, 360 / LedColumns);
                    }
                }
            }

            return -1;
        }
    }
}