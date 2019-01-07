using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FourierAudio
{
    public partial class ucSoundDisplay : UserControl
    {
        public ucSoundDisplay()
        {
            InitializeComponent();
        }

        private MySoundPlayer player;
        private SoundFile file;
        private Graphics graphics;
        // input:
        private int _centerIndex; // use property
        private double scaleFact;

        public void Reset(MySoundPlayer player)
        {
            this.player = player;
            file = player.File;
            centerIndex = pictureBox.Width / 2;
            scaleFact = 1.0;

            createBitmap();
        }

        private bool createBitmap()
        {
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
            // update();
            return true;
        }

        private int centerIndex
        {
            get { return _centerIndex; }
            set { _centerIndex = Math.Min(Math.Max(value, 0), file.NumSamples); }
        }

        public new void Update()
        {
            // drawer.Draw(graphics, Width, Height, centerIndex, scaleFact, playing, chkSpectrum.Checked, tbrSpectN.Value, tbrSamStep.Value);
            pictureBox.Refresh();
            base.Update();
        }
    }
}
