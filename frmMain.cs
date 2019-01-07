// 20-12-2015, BVH

using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace FourierAudio
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            MouseWheel += FrmMain_MouseWheel;
        }

        private SoundFile file;
        private MySoundPlayer player;
        private ucSoundDisplay display;

        private void openFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Wave Files (.wav)|*.wav|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Load file and objects
                file = SoundLoader.ReadFile(dialog.FileName);
                player = new MySoundPlayer(file);

                // Prepare graphics
                display.Reset(player);
                updateInfoText();
                updateAll();

                // Restart if needed
                if (player.State == MySoundPlayer.PlayerState.Playing)
                    player.Restart();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void pic_DoubleClick(object sender, EventArgs e)
        {
            openFile();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            player.Toggle();
            switch (player.State)
            {
                case MySoundPlayer.PlayerState.Playing:
                    btnPlay.Text = "&Stop";
                    tmrPlayScroll.Start();
                    break;
                case MySoundPlayer.PlayerState.Stopped:
                    btnPlay.Text = "&Play";
                    tmrPlayScroll.Stop();
                    break;
            }
            updateAll();
        }

        private void updateInfoText()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ChunkID: " + file.ChunkID)
                .AppendLine("ChunkSize: " + file.ChunkSize)
                .AppendLine("Format: " + file.Format)
                .AppendLine("Subchunk1ID: " + file.Subchunk1ID)
                .AppendLine("Subchunk1Size: " + file.Subchunk1Size)
                .AppendLine("AudioFormat: " + file.AudioFormat)
                .AppendLine("NumChannels: " + file.NumChannels)
                .AppendLine("SampleRate: " + file.SampleRate)
                .AppendLine("ByteRate: " + file.ByteRate)
                .AppendLine("BlockAlign: " + file.BlockAlign)
                .AppendLine("BitsPerSample: " + file.BitsPerSample)
                .AppendLine("Subchunk2ID: " + file.Subchunk2ID)
                .AppendLine("Subchunk2Size: " + file.Subchunk2Size)
                .AppendLine("NumSamples: " + file.NumSamples)
                .AppendLine("LengthMs: " + file.LengthMs);
            lblInfo.Text = builder.ToString();
        }

        private void updateAll()
        {
            if (file == null)
                return;
            updateScroll();
            display.Update();
        }

        private void updateScroll()
        {
            // picScroll.Left = picScrollBG.Left + Math.Min(Math.Max(mouseX - picScroll.Width / 2, 0), picScrollBG.Width - picScroll.Width);
            // startIndex = data.NumSamples * (picScroll.Left - picScrollBG.Left) / picScrollBG.Width;
            /*picScroll.Width = (int)(picScrollBG.Width * (display.Width * scaleFact) / file.NumSamples);
            picScroll.Left = (int)(picScrollBG.Left + (double)centerIndex * picScrollBG.Width / file.NumSamples - picScroll.Width / 2);
            picScrollBG.Refresh();
            lblSample.Text = "Sample: " + centerIndex + " / " + file.NumSamples;
            lblSample.Refresh();*/
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (!tmrUpdate.Enabled)
                tmrUpdate.Start();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            /*if (WindowState != FormWindowState.Minimized)
                createBitmap();*/
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
            if (file == null || mouseX == lastMouseX)
                return;
            // centerIndex = (int)(file.NumSamples * (double)(mouseX) / picScrollBG.Width);
            if (player.State == MySoundPlayer.PlayerState.Stopped)
                updateAll();
            mouseX = lastMouseX;
        }

        private void FrmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            /*if ((ModifierKeys & Keys.Control) == Keys.Control)
                scaleFact = Math.Max(scaleFact * Math.Exp(-e.Delta / 500.0), 0.5);
            else
                centerIndex -= (int)(e.Delta / 4.0 * scaleFact);*/
            if (player.State == MySoundPlayer.PlayerState.Stopped)
                updateAll();
            // lblSample.Text = "Delta: " + e.Delta + ", scaleFact: " + scaleFact;
        }

        private void tmrPlayScroll_Tick(object sender, EventArgs e)
        {
            /*double elapsed = (DateTime.Now - playStart).TotalSeconds + 0.05; // correction
            centerIndex = (int)(elapsed * data.SampleRate % data.NumSamples);*/
            updateAll();
        }

        private void tbrSpectN_Scroll(object sender, EventArgs e)
        {
            lblSpectN.Text = "N = " + tbrSpectN.Value;
            if (player.State == MySoundPlayer.PlayerState.Stopped)
                updateAll();
        }

        private void tbrSamStep_Scroll(object sender, EventArgs e)
        {
            lblSamStep.Text = "Step = " + tbrSamStep.Value;
            if (player.State == MySoundPlayer.PlayerState.Stopped)
                updateAll();
        }
    }
}
