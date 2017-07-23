using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace FidgetSpinnerEditor
{
    public partial class FormMain : Form
    {
        private const int LedRows = 16, LedColumns = 120;
        private BitArray _bits = new BitArray(LedRows * LedColumns);
        private PointF _center;
        private Brush _colorBody, _colorEnabled, _colorDisabled;
        private Rectangle _drawingArea;
        private Timer _importTimer;
        private RectangleF _innerDrawingArea;
        private string _lastFile;
        private int _ledSize, _rotation;
        private const double LedAngleBetweenColumns = 360 / LedColumns;

        public FormMain()
        {
            InitializeComponent();
            UpdateGui();
            fileSystemWatcherExternalEditor.EnableRaisingEvents = false;
            //pictureBoxEditor.AllowDrop = true;

            // Default colors
            colorDialogBody.Color = Color.Yellow;
            colorDialogHoles.Color = Color.LightGoldenrodYellow;
            colorDialogLights.Color = Color.Blue;
            UpdateColors();
            UpdateGui();
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
            e.Graphics.FillEllipse(_colorBody, _drawingArea);
            e.Graphics.DrawEllipse(Pens.Black, _drawingArea);

            e.Graphics.FillEllipse(Brushes.White, _innerDrawingArea);
            e.Graphics.DrawEllipse(Pens.Black, _innerDrawingArea);

            var yspacing = (_drawingArea.Height - _innerDrawingArea.Height) / 2 / (LedRows + 1);
            for (var i = 0; i < LedRows; i++)
            {
                var p = new PointF(_center.X, _drawingArea.Top + yspacing * (1 + i));
                var r = _rotation;

                for (var j = 0; j < LedColumns; j++)
                {
                    p = RotatePoint(p, _center, r + LedAngleBetweenColumns);
                    r = 0;

                    e.Graphics.FillEllipse(GetBit(i + j * LedRows) ? _colorEnabled : _colorDisabled,
                        p.X - _ledSize / 2, p.Y - _ledSize / 2, _ledSize, _ledSize);
                }
            }
        }

        private void LoadBin(string path)
        {
            _lastFile = path;
            _bits = new BitArray(File.ReadAllBytes(path).SelectMany(GetBits).ToArray());
            pictureBoxEditor.Invalidate();
            UpdateGui();
        }

        private void UpdateGui()
        {
            externalEditorToolStripMenuItem.Checked = fileSystemWatcherExternalEditor.EnableRaisingEvents;
            openNextFileToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_lastFile);
            Text = (string.IsNullOrEmpty(_lastFile) ? "" : Path.GetFileName(_lastFile) + " - ") +
                   "Fidget Spinner Editor";
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
                X = (float) (cosTheta * (pointToRotate.X - centerPoint.X) -
                             sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y = (float) (sinTheta * (pointToRotate.X - centerPoint.X) +
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
                LoadBin(openFileDialogBin.FileName);
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
            MessageBox.Show(
                "Create or edit by clicking or dragging on the spinner. Use the left mouse button to draw " +
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

        private void counterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rotation -= 5;
            pictureBoxEditor.Invalidate();
        }

        private void bodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialogBody.ShowDialog();
            UpdateColors();
        }

        private void UpdateColors()
        {
            _colorBody = new SolidBrush(colorDialogBody.Color);
            _colorDisabled = new SolidBrush(colorDialogHoles.Color);
            _colorEnabled = new SolidBrush(colorDialogLights.Color);
            pictureBoxEditor.Invalidate();
        }

        private void lightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialogLights.ShowDialog();
            UpdateColors();
        }

        private void holesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialogHoles.ShowDialog();
            UpdateColors();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bits.SetAll(false);
            _lastFile = null;
            UpdateGui();
            pictureBoxEditor.Invalidate();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bits.Not();
            pictureBoxEditor.Invalidate();
        }

        private void pictureBoxEditor_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Move;
        }

        private void pictureBoxEditor_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void openNextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loadNext = false;
            var files = Directory.GetFiles(Path.GetDirectoryName(_lastFile), "*.bin");

            if (!files.Any())
                return;

            foreach (var f in files)
                if (f == _lastFile)
                {
                    loadNext = true;
                }
                else if (loadNext)
                {
                    LoadBin(f);
                    return;
                }

            LoadBin(files[0]);

            /*MessageBox.Show(_lastFile + " is the last file in the directory.\n\nOpen another file and retry.",
                "Next file", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);*/
        }

        private void externalEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fileSystemWatcherExternalEditor.EnableRaisingEvents)
            {
                var tmp = Path.GetTempFileName();
                File.Delete(tmp);
                Directory.CreateDirectory(tmp);

                var filename = Path.GetFileNameWithoutExtension(tmp) + ".bmp";
                var f = Path.Combine(tmp, filename);
                ExportImage(f, true);
                ShowOpenWithDialog(f);
                fileSystemWatcherExternalEditor.Filter = filename;
                fileSystemWatcherExternalEditor.Path = tmp;
            }

            fileSystemWatcherExternalEditor.EnableRaisingEvents = !fileSystemWatcherExternalEditor.EnableRaisingEvents;
            UpdateGui();
        }

        public static void ShowOpenWithDialog(string path)
        {
            var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
            args += ",OpenAs_RunDLL " + path;
            Process.Start("rundll32.exe", args);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogImport.ShowDialog() == DialogResult.OK)
                ImportImage(openFileDialogImport.FileName);
        }

        private void ImportImage(string filename)
        {
            try
            {
                using (var fs = new FileStream(filename, FileMode.Open))
                {
                    var b = new Bitmap(fs);

                    for (var x = 0; x < Math.Min(b.Width, LedColumns); x++)
                    for (var y = 0; y < Math.Min(b.Height, LedRows); y++)
                    {
                        var p = b.GetPixel(x, y);
                        _bits[y + x * LedRows] = (p.R + p.G + p.B) / 3 < 100;
                    }

                    b.Dispose();
                    pictureBoxEditor.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while importing: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void fileSystemWatcherExternalEditor_Changed(object sender, FileSystemEventArgs e)
        {
            _importTimer?.Dispose();
            _importTimer = new Timer(o => ImportImage(e.FullPath), null, 100, Timeout.Infinite);
        }

        private void reverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmp = new bool[_bits.Count];

            var i = 0;// LedColumns*LedRows;
                      /*for (var x = 0; x < LedColumns; x++)
                          for (var y = 0; y < LedRows; y++)*/
            for (var x = LedColumns-1; x>=0; x--)
                //  for (var y = LedRows-1; y >=0; y--)
                for (var y = 0; y < LedRows; y++)
                    tmp[i++] = _bits[x * LedRows + y];

            _bits = new BitArray(tmp);
            pictureBoxEditor.Invalidate();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogExport.ShowDialog() == DialogResult.OK)
                ExportImage(saveFileDialogExport.FileName);
        }

        private void ExportImage(string filename, bool silent = false)
        {
            var b = new Bitmap(LedColumns, LedRows);

            for (var x = 0; x < LedColumns; x++)
            for (var y = 0; y < LedRows; y++)
                b.SetPixel(x, y, GetBit(x * LedRows + y) ? Color.Black : Color.White);

            try
            {
                b.Save(filename, ImageFormat.Bmp);

                if (!silent)
                    MessageBox.Show("File exported to: " + filename, "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while exporting: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void clockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rotation += 5;
            pictureBoxEditor.Invalidate();
        }

        private int GetBitByPosition(Point point)
        {
            if (!_drawingArea.IsEmpty && !_innerDrawingArea.IsEmpty && !_center.IsEmpty)
            {
                var yspacing = (_drawingArea.Height - _innerDrawingArea.Height) / 2 / (LedRows + 1);
                for (var i = 0; i < LedRows; i++)
                {
                    var p = new PointF(_center.X, _drawingArea.Top + yspacing * (1 + i));
                    var r = _rotation;

                    for (var j = 0; j < LedColumns; j++)
                    {
                        p = RotatePoint(p, _center, r + LedAngleBetweenColumns);
                        r = 0;

                        if (new RectangleF(p.X - _ledSize / 2, p.Y - _ledSize / 2, _ledSize, _ledSize).Contains(point))
                            return i + j * LedRows;
                    }
                }
            }
            return -1;
        }
    }
}