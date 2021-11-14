using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PlanetStitch
{
    public partial class FormMain : Form
    {

        private readonly ImageList PlanetFrames = new ImageList()
        {
            ImageSize = new Size(128, 128),
            ColorDepth = ColorDepth.Depth32Bit
        };

        private System.Timers.Timer FrameTimer = new System.Timers.Timer()
        {
            Enabled = false,
            Interval = 50
        };

        private Bitmap Atlas { get; set; }

        private int Frame { get; set; } = 0;

        private string[] ImageFileList { get; set; }

        private readonly FormTextureAtlas TextureWindow = new FormTextureAtlas();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FrameTimer.Elapsed += FrameTimer_Elapsed;
            TextureWindow.Location = new Point(Location.X - TextureWindow.Width - 10, Location.Y - 25);
        }


        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ++Frame;
            Frame %= PlanetFrames.Images.Count;
            pictureBox1.Image = PlanetFrames.Images[Frame];
        }

        private void ButtonLoadFolder_Click(object sender, EventArgs e)
        {
            SetUiButtonState(false);

            FrameTimer.Enabled = false;

            pictureBox1.Image = null;
            TextureWindow.Texture = null;

            if (ShowFileDialog())
            {
                pictureBox1.Image = Properties.Resources.spinner;
                ImageProcessingWorker.RunWorkerAsync();
            }
        }

        private void SetUiButtonState(bool enabled)
        {
            ButtonLoadFolder.Enabled = enabled;
            ButtonSaveTexture.Enabled = enabled;
        }


        private bool ShowFileDialog()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            string lastPath = Properties.Settings.Default.LastOpenedPath;
            if (!string.IsNullOrEmpty(lastPath) && Directory.Exists(lastPath))
            {
                fbd.SelectedPath = lastPath;
            }

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(fbd.SelectedPath)) { return false; }

                Properties.Settings.Default.LastOpenedPath = fbd.SelectedPath;
                Properties.Settings.Default.Save();

                ImageFileList = Directory.GetFiles(fbd.SelectedPath);
            }
            else
            {
                return false;
            }

            return true;
        }

        private void LoadImageList()
        {
            PlanetFrames.Images.Clear();

            foreach (string name in ImageFileList)
            {
                /// naive
                if (!name.EndsWith(".png")) { continue; }
                PlanetFrames.Images.Add(Image.FromFile(name));
            }
        }

        private void BuildPlanetTexture()
        {
            if (Atlas != null)
            {
                Atlas.Dispose();
            }

            Atlas = new Bitmap(2048, 2048);
            Graphics graphics = Graphics.FromImage(Atlas);
            for (int i = 0; i < PlanetFrames.Images.Count && i < 256; ++i)
            {
                graphics.DrawImage(PlanetFrames.Images[i], (i % 16) * 128, (i / 16) * 128);
            }
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAs = new SaveFileDialog
            {
                AddExtension = true,
                Title = "Save Planet Atlas",
                Filter = "PNG Image|.png",
                FileName = "*.png",
                DefaultExt = "png",
                SupportMultiDottedExtensions = true
            };

            string savePath = Properties.Settings.Default.LastSavedPath;

            if (!string.IsNullOrEmpty(savePath)
                && Directory.Exists(savePath))
            {
                saveAs.InitialDirectory = savePath;
            }

            if (saveAs.ShowDialog() == DialogResult.OK &&
                !string.IsNullOrEmpty(saveAs.FileName))
            {
                Atlas.Save(saveAs.FileName, System.Drawing.Imaging.ImageFormat.Png);

                FileInfo fileInfo = new FileInfo(saveAs.FileName);
                Properties.Settings.Default.LastSavedPath = fileInfo.DirectoryName;
            }
        }

        private void ImageProcessingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadImageList();
            BuildPlanetTexture();
        }

        private void ImageProcessingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetUiButtonState(true);
            TextureWindow.Texture = Atlas;
            FrameTimer.Enabled = PlanetFrames.Images.Count > 0;
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://wiki.outpost2.net/doku.php?id=opu_projects:active_projects:outposthd:planetstitch");
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            TextureWindow.Show();
        }
    }
}
