namespace FourierSong
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.picScrollBG = new System.Windows.Forms.PictureBox();
            this.picScroll = new System.Windows.Forms.PictureBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.chkSpectrum = new System.Windows.Forms.CheckBox();
            this.tbrSpectN = new System.Windows.Forms.TrackBar();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tmrPlayScroll = new System.Windows.Forms.Timer(this.components);
            this.tbrSamStep = new System.Windows.Forms.TrackBar();
            this.lblSpectN = new System.Windows.Forms.Label();
            this.lblSamStep = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScrollBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpectN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSamStep)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(1086, 643);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.DoubleClick += new System.EventHandler(this.pic_DoubleClick);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Location = new System.Drawing.Point(12, 12);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(27, 15);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Info";
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLeft.AutoSize = true;
            this.lblLeft.ForeColor = System.Drawing.Color.Lime;
            this.lblLeft.Location = new System.Drawing.Point(12, 616);
            this.lblLeft.Margin = new System.Windows.Forms.Padding(3);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(27, 15);
            this.lblLeft.TabIndex = 2;
            this.lblLeft.Text = "Left";
            // 
            // lblRight
            // 
            this.lblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRight.AutoSize = true;
            this.lblRight.ForeColor = System.Drawing.Color.Red;
            this.lblRight.Location = new System.Drawing.Point(45, 616);
            this.lblRight.Margin = new System.Windows.Forms.Padding(3);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(36, 15);
            this.lblRight.TabIndex = 3;
            this.lblRight.Text = "Right";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // picScrollBG
            // 
            this.picScrollBG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picScrollBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(80)))), ((int)(((byte)(96)))));
            this.picScrollBG.Location = new System.Drawing.Point(330, 12);
            this.picScrollBG.Name = "picScrollBG";
            this.picScrollBG.Size = new System.Drawing.Size(734, 32);
            this.picScrollBG.TabIndex = 4;
            this.picScrollBG.TabStop = false;
            this.picScrollBG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picScrollBG_MouseDown);
            this.picScrollBG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picScrollBG_MouseMove);
            // 
            // picScroll
            // 
            this.picScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.picScroll.Location = new System.Drawing.Point(330, 16);
            this.picScroll.Name = "picScroll";
            this.picScroll.Size = new System.Drawing.Size(60, 24);
            this.picScroll.TabIndex = 5;
            this.picScroll.TabStop = false;
            this.picScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picScroll_MouseDown);
            this.picScroll.MouseEnter += new System.EventHandler(this.picScroll_MouseEnter);
            this.picScroll.MouseLeave += new System.EventHandler(this.picScroll_MouseLeave);
            this.picScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picScroll_MouseMove);
            // 
            // lblSample
            // 
            this.lblSample.AutoSize = true;
            this.lblSample.Location = new System.Drawing.Point(327, 50);
            this.lblSample.Margin = new System.Windows.Forms.Padding(3);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(60, 15);
            this.lblSample.TabIndex = 6;
            this.lblSample.Text = "Sample #";
            // 
            // chkSpectrum
            // 
            this.chkSpectrum.AutoSize = true;
            this.chkSpectrum.Checked = true;
            this.chkSpectrum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpectrum.Location = new System.Drawing.Point(330, 71);
            this.chkSpectrum.Name = "chkSpectrum";
            this.chkSpectrum.Size = new System.Drawing.Size(111, 19);
            this.chkSpectrum.TabIndex = 7;
            this.chkSpectrum.Text = "&Draw Spectrum";
            this.chkSpectrum.UseVisualStyleBackColor = true;
            // 
            // tbrSpectN
            // 
            this.tbrSpectN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbrSpectN.LargeChange = 100;
            this.tbrSpectN.Location = new System.Drawing.Point(550, 50);
            this.tbrSpectN.Maximum = 910;
            this.tbrSpectN.Minimum = 10;
            this.tbrSpectN.Name = "tbrSpectN";
            this.tbrSpectN.Size = new System.Drawing.Size(434, 45);
            this.tbrSpectN.SmallChange = 20;
            this.tbrSpectN.TabIndex = 8;
            this.tbrSpectN.TickFrequency = 50;
            this.tbrSpectN.Value = 135;
            this.tbrSpectN.Scroll += new System.EventHandler(this.tbrSpectN_Scroll);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(80)))), ((int)(((byte)(96)))));
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(144)))), ((int)(((byte)(160)))));
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(220, 12);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 32);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "&Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // tmrPlayScroll
            // 
            this.tmrPlayScroll.Interval = 25;
            this.tmrPlayScroll.Tick += new System.EventHandler(this.tmrPlayScroll_Tick);
            // 
            // tbrSamStep
            // 
            this.tbrSamStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbrSamStep.LargeChange = 10;
            this.tbrSamStep.Location = new System.Drawing.Point(550, 90);
            this.tbrSamStep.Maximum = 51;
            this.tbrSamStep.Minimum = 1;
            this.tbrSamStep.Name = "tbrSamStep";
            this.tbrSamStep.Size = new System.Drawing.Size(434, 45);
            this.tbrSamStep.SmallChange = 2;
            this.tbrSamStep.TabIndex = 10;
            this.tbrSamStep.TickFrequency = 5;
            this.tbrSamStep.Value = 8;
            this.tbrSamStep.Scroll += new System.EventHandler(this.tbrSamStep_Scroll);
            // 
            // lblSpectN
            // 
            this.lblSpectN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpectN.AutoSize = true;
            this.lblSpectN.Location = new System.Drawing.Point(990, 58);
            this.lblSpectN.Margin = new System.Windows.Forms.Padding(3);
            this.lblSpectN.Name = "lblSpectN";
            this.lblSpectN.Size = new System.Drawing.Size(50, 15);
            this.lblSpectN.TabIndex = 11;
            this.lblSpectN.Text = "N = 135";
            // 
            // lblSamStep
            // 
            this.lblSamStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSamStep.AutoSize = true;
            this.lblSamStep.Location = new System.Drawing.Point(990, 98);
            this.lblSamStep.Margin = new System.Windows.Forms.Padding(3);
            this.lblSamStep.Name = "lblSamStep";
            this.lblSamStep.Size = new System.Drawing.Size(52, 15);
            this.lblSamStep.TabIndex = 12;
            this.lblSamStep.Text = "Step = 8";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(80)))), ((int)(((byte)(96)))));
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(144)))), ((int)(((byte)(160)))));
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(130, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 32);
            this.btnOpen.TabIndex = 13;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1086, 643);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblSamStep);
            this.Controls.Add(this.lblSpectN);
            this.Controls.Add(this.tbrSamStep);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.tbrSpectN);
            this.Controls.Add(this.chkSpectrum);
            this.Controls.Add(this.lblSample);
            this.Controls.Add(this.picScroll);
            this.Controls.Add(this.picScrollBG);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.pic);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Fourier Song";
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScrollBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpectN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSamStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.PictureBox picScrollBG;
        private System.Windows.Forms.PictureBox picScroll;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.CheckBox chkSpectrum;
        private System.Windows.Forms.TrackBar tbrSpectN;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Timer tmrPlayScroll;
        private System.Windows.Forms.TrackBar tbrSamStep;
        private System.Windows.Forms.Label lblSpectN;
        private System.Windows.Forms.Label lblSamStep;
        private System.Windows.Forms.Button btnOpen;
    }
}

