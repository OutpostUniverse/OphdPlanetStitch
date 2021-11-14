
namespace PlanetStitch
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ButtonLoadFolder = new System.Windows.Forms.Button();
            this.ButtonSaveTexture = new System.Windows.Forms.Button();
            this.ImageProcessingWorker = new System.ComponentModel.BackgroundWorker();
            this.ButtonHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(33, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // ButtonLoadFolder
            // 
            this.ButtonLoadFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonLoadFolder.Location = new System.Drawing.Point(33, 146);
            this.ButtonLoadFolder.Name = "ButtonLoadFolder";
            this.ButtonLoadFolder.Size = new System.Drawing.Size(128, 23);
            this.ButtonLoadFolder.TabIndex = 1;
            this.ButtonLoadFolder.Text = "Load Folder...";
            this.ButtonLoadFolder.UseVisualStyleBackColor = true;
            this.ButtonLoadFolder.Click += new System.EventHandler(this.ButtonLoadFolder_Click);
            // 
            // ButtonSaveTexture
            // 
            this.ButtonSaveTexture.Enabled = false;
            this.ButtonSaveTexture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonSaveTexture.Location = new System.Drawing.Point(33, 175);
            this.ButtonSaveTexture.Name = "ButtonSaveTexture";
            this.ButtonSaveTexture.Size = new System.Drawing.Size(127, 23);
            this.ButtonSaveTexture.TabIndex = 2;
            this.ButtonSaveTexture.Text = "Save Atlas...";
            this.ButtonSaveTexture.UseVisualStyleBackColor = true;
            this.ButtonSaveTexture.Click += new System.EventHandler(this.ButtonSaveAs_Click);
            // 
            // ImageProcessingWorker
            // 
            this.ImageProcessingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ImageProcessingWorker_DoWork);
            this.ImageProcessingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ImageProcessingWorker_RunWorkerCompleted);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonHelp.Location = new System.Drawing.Point(33, 204);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(127, 23);
            this.ButtonHelp.TabIndex = 3;
            this.ButtonHelp.Text = "Help...";
            this.ButtonHelp.UseVisualStyleBackColor = true;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.ButtonSaveTexture;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(194, 236);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.ButtonSaveTexture);
            this.Controls.Add(this.ButtonLoadFolder);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlanetStitch";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonLoadFolder;
        private System.Windows.Forms.Button ButtonSaveTexture;
        private System.ComponentModel.BackgroundWorker ImageProcessingWorker;
        private System.Windows.Forms.Button ButtonHelp;
    }
}

