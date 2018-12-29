// 20-12-2015, BVH

using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace FourierSong
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            createBmp();
            MouseWheel += FrmMain_MouseWheel;
        }

        private SoundData data;
        private SoundDrawer drawer;

        private void pic_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Wave Files (.wav)|*.wav|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                data = new SoundData(dialog.FileName);
                drawer = new SoundDrawer(data);
                fileLoaded();
            }
        }

        private void fileLoaded()
        {
            centerIndex = pic.Width / 2;
            scaleFact = 1.0;
            setInfo();
            createBmp();
            if (playing)
            {
                btnPlay_Click(null, null); // stop
                btnPlay_Click(null, null); // start
            }
        }

        private void setInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ChunkID: " + data.ChunkID)
                .AppendLine("ChunkSize: " + data.ChunkSize)
                .AppendLine("Format: " + data.Format)
                .AppendLine("Subchunk1ID: " + data.Subchunk1ID)
                .AppendLine("Subchunk1Size: " + data.Subchunk1Size)
                .AppendLine("AudioFormat: " + data.AudioFormat)
                .AppendLine("NumChannels: " + data.NumChannels)
                .AppendLine("SampleRate: " + data.SampleRate)
                .AppendLine("ByteRate: " + data.ByteRate)
                .AppendLine("BlockAlign: " + data.BlockAlign)
                .AppendLine("BitsPerSample: " + data.BitsPerSample)
                .AppendLine("Subchunk2ID: " + data.Subchunk2ID)
                .AppendLine("Subchunk2Size: " + data.Subchunk2Size)
                .AppendLine("NumSamples: " + data.NumSamples)
                .AppendLine("LengthMs: " + data.LengthMs);
            lblInfo.Text = builder.ToString();
        }

        private bool createBmp()
        {
            if (drawer == null)
                return false;
            pic.Image = new Bitmap(pic.Width, pic.Height);
            gfx = Graphics.FromImage(pic.Image);
            update();
            return true;
        }

        private Graphics gfx;
        // input:
        private int _centerIndex; // use property
        private double scaleFact;

        private int centerIndex
        {
            get { return _centerIndex; }
            set { _centerIndex = Math.Min(Math.Max(value, 0), data.NumSamples); }
        }

        private void update()
        {
            if (data == null || drawer == null)
                return;
            updateScroll();
            updatePic();
        }

        private void updateScroll()
        {
            // picScroll.Left = picScrollBG.Left + Math.Min(Math.Max(mouseX - picScroll.Width / 2, 0), picScrollBG.Width - picScroll.Width);
            // startIndex = data.NumSamples * (picScroll.Left - picScrollBG.Left) / picScrollBG.Width;
            picScroll.Width = (int)(picScrollBG.Width * (pic.Width * scaleFact) / data.NumSamples);
            picScroll.Left = (int)(picScrollBG.Left + (double)centerIndex * picScrollBG.Width / data.NumSamples - picScroll.Width / 2);
            picScrollBG.Refresh();
            lblSample.Text = "Sample: " + centerIndex + " / " + data.NumSamples;
            lblSample.Refresh();
        }

        private void updatePic()
        {
            drawer.Draw(gfx, pic.Width, pic.Height, centerIndex, scaleFact, playing, chkSpectrum.Checked, tbrSpectN.Value, tbrSamStep.Value);
            pic.Refresh();
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (!tmrUpdate.Enabled)
                tmrUpdate.Start();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                createBmp();
            tmrUpdate.Stop();
        }

        #region "Scroll events"

        private void picScroll_MouseEnter(object sender, EventArgs e)
        {
            picScroll.BackColor = Color.FromArgb(224, 232, 240);
        }

        private void picScroll_MouseLeave(object sender, EventArgs e)
        {
            picScroll.BackColor = Color.FromArgb(192, 208, 224);
        }

        private void picScroll_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                moveScroll((picScroll.Left - picScrollBG.Left) + e.X);
        }

        private void picScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                moveScroll((picScroll.Left - picScrollBG.Left) + e.X);
        }

        private void picScrollBG_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                moveScroll(e.X);
        }

        private void picScrollBG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                moveScroll(e.X);
        }

        #endregion

        private int lastMouseX = -1;

        // mouseX relative to ScrollBG.Left
        private void moveScroll(int mouseX)
        {
            if (data == null || mouseX == lastMouseX)
                return;
            centerIndex = (int)(data.NumSamples * (double)(mouseX) / picScrollBG.Width);
            if (!playing)
                update();
            mouseX = lastMouseX;
        }

        private void FrmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
                scaleFact = Math.Max(scaleFact * Math.Exp(-e.Delta / 500.0), 0.5);
            else
                centerIndex -= (int)(e.Delta / 4.0 * scaleFact);
            if (!playing)
                update();
            // lblSample.Text = "Delta: " + e.Delta + ", scaleFact: " + scaleFact;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            pic_DoubleClick(null, null);
        }

        private bool playing = false;
        private SoundPlayer player;
        private DateTime playStart;

        private void btnPlay_Click(object sender, EventArgs e)
        {
            playing = !playing;
            if (playing)
            {
                MemoryStream stream = new MemoryStream(data.FileBytes);
                // stream.Seek(100000, SeekOrigin.Begin);
                player = new SoundPlayer(stream);
                player.PlayLooping();
                playStart = DateTime.Now;
                btnPlay.Text = "&Stop";
            }
            else
            {
                player.Stop();
                btnPlay.Text = "&Play";
                update();
            }
            tmrPlayScroll.Enabled = playing;
        }

        private void tmrPlayScroll_Tick(object sender, EventArgs e)
        {
            double elapsed = (DateTime.Now - playStart).TotalSeconds + 0.05; // correction
            centerIndex = (int)(elapsed * data.SampleRate % data.NumSamples);
            update();
        }

        private void tbrSpectN_Scroll(object sender, EventArgs e)
        {
            lblSpectN.Text = "N = " + tbrSpectN.Value;
            if (!playing)
                update();
        }

        private void tbrSamStep_Scroll(object sender, EventArgs e)
        {
            lblSamStep.Text = "Step = " + tbrSamStep.Value;
            if (!playing)
                update();
        }
    }
}
