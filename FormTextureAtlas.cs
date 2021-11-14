using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanetStitch
{
    public partial class FormTextureAtlas : Form
    {
        public Bitmap Texture
        {
            get => (Bitmap)pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        public FormTextureAtlas()
        {
            InitializeComponent();
        }

        private void FormTextureAtlas_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
