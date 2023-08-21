namespace BDObarterNEXT
{
    partial class Dialog
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
            {   components.Dispose();
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
            this.dialButtonBorder = new System.Windows.Forms.Button();
            this.dialTrackBarScale = new System.Windows.Forms.TrackBar();
            this.dialButtonExit = new System.Windows.Forms.Button();
            this.labelScale = new System.Windows.Forms.Label();
            this.dialButtonTextOut = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.toolTipWarning = new System.Windows.Forms.ToolTip(this.components);
            this.panelUp = new System.Windows.Forms.Panel();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkDeActive = new System.Windows.Forms.CheckBox();
            this.checkSound = new System.Windows.Forms.CheckBox();
            this.checkBox_Block = new System.Windows.Forms.CheckBox();
            this.dialButtonReset = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dialTrackBarScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.panelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dialButtonBorder
            // 
            this.dialButtonBorder.BackColor = System.Drawing.Color.Beige;
            this.dialButtonBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dialButtonBorder.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dialButtonBorder.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dialButtonBorder.Location = new System.Drawing.Point(12, 81);
            this.dialButtonBorder.Name = "dialButtonBorder";
            this.dialButtonBorder.Size = new System.Drawing.Size(82, 23);
            this.dialButtonBorder.TabIndex = 1;
            this.dialButtonBorder.Text = "Бордюр";
            this.dialButtonBorder.UseVisualStyleBackColor = false;
            this.dialButtonBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dialButtonBorder_MouseDown);
            // 
            // dialTrackBarScale
            // 
            this.dialTrackBarScale.BackColor = System.Drawing.SystemColors.Control;
            this.dialTrackBarScale.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.dialTrackBarScale.Location = new System.Drawing.Point(12, 162);
            this.dialTrackBarScale.Maximum = 80;
            this.dialTrackBarScale.Minimum = 20;
            this.dialTrackBarScale.Name = "dialTrackBarScale";
            this.dialTrackBarScale.Size = new System.Drawing.Size(156, 45);
            this.dialTrackBarScale.TabIndex = 2;
            this.dialTrackBarScale.TickFrequency = 5;
            this.dialTrackBarScale.Value = 50;
            this.dialTrackBarScale.ValueChanged += new System.EventHandler(this.dialTrackBarScale_ValueChanged);
            // 
            // dialButtonExit
            // 
            this.dialButtonExit.BackColor = System.Drawing.SystemColors.Control;
            this.dialButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dialButtonExit.Font = new System.Drawing.Font("Georgia", 5.25F);
            this.dialButtonExit.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dialButtonExit.Location = new System.Drawing.Point(176, 234);
            this.dialButtonExit.Name = "dialButtonExit";
            this.dialButtonExit.Size = new System.Drawing.Size(96, 20);
            this.dialButtonExit.TabIndex = 3;
            this.dialButtonExit.Text = "ВЫХОД";
            this.dialButtonExit.UseVisualStyleBackColor = false;
            this.dialButtonExit.Click += new System.EventHandler(this.dialButtonExit_Click);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScale.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelScale.Location = new System.Drawing.Point(12, 146);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(70, 14);
            this.labelScale.TabIndex = 4;
            this.labelScale.Text = "Масштаб: ";
            // 
            // dialButtonTextOut
            // 
            this.dialButtonTextOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.dialButtonTextOut.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dialButtonTextOut.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dialButtonTextOut.Location = new System.Drawing.Point(12, 110);
            this.dialButtonTextOut.Name = "dialButtonTextOut";
            this.dialButtonTextOut.Size = new System.Drawing.Size(82, 23);
            this.dialButtonTextOut.TabIndex = 5;
            this.dialButtonTextOut.Text = "Текст";
            this.dialButtonTextOut.UseVisualStyleBackColor = false;
            this.dialButtonTextOut.Click += new System.EventHandler(this.dialButtonTextOut_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarOpacity.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBarOpacity.Location = new System.Drawing.Point(12, 224);
            this.trackBarOpacity.Maximum = 80;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(105, 45);
            this.trackBarOpacity.TabIndex = 6;
            this.trackBarOpacity.TickFrequency = 10;
            this.trackBarOpacity.Value = 10;
            this.trackBarOpacity.ValueChanged += new System.EventHandler(this.trackBarOpacity_ValueChanged);
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOpacity.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelOpacity.Location = new System.Drawing.Point(12, 207);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(105, 14);
            this.labelOpacity.TabIndex = 7;
            this.labelOpacity.Text = "Прозрачность: ";
            // 
            // toolTipWarning
            // 
            this.toolTipWarning.BackColor = System.Drawing.Color.Pink;
            this.toolTipWarning.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolTipWarning.IsBalloon = true;
            this.toolTipWarning.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipWarning.ToolTipTitle = "Ахтунг!";
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUp.Controls.Add(this.buttonHelp);
            this.panelUp.Controls.Add(this.buttonClose);
            this.panelUp.Controls.Add(this.label1);
            this.panelUp.Location = new System.Drawing.Point(1, 3);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(282, 29);
            this.panelUp.TabIndex = 13;
            // 
            // buttonHelp
            // 
            this.buttonHelp.ForeColor = System.Drawing.Color.Navy;
            this.buttonHelp.Location = new System.Drawing.Point(178, 1);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(22, 20);
            this.buttonHelp.TabIndex = 16;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonHelp_MouseDown);
            // 
            // buttonClose
            // 
            this.buttonClose.ForeColor = System.Drawing.Color.Navy;
            this.buttonClose.Location = new System.Drawing.Point(206, 1);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(63, 20);
            this.buttonClose.TabIndex = 15;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonClose_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(5, -7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Настройки";
            // 
            // checkDeActive
            // 
            this.checkDeActive.AutoSize = true;
            this.checkDeActive.BackgroundImage = global::BDObarterNEXT.Properties.Resources.dialback_;
            this.checkDeActive.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkDeActive.Checked = true;
            this.checkDeActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDeActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkDeActive.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkDeActive.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkDeActive.Location = new System.Drawing.Point(176, 210);
            this.checkDeActive.Name = "checkDeActive";
            this.checkDeActive.Size = new System.Drawing.Size(96, 18);
            this.checkDeActive.TabIndex = 14;
            this.checkDeActive.Text = "Деактив   ";
            this.checkDeActive.UseVisualStyleBackColor = true;
            // 
            // checkSound
            // 
            this.checkSound.AutoSize = true;
            this.checkSound.BackgroundImage = global::BDObarterNEXT.Properties.Resources.dialback_;
            this.checkSound.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkSound.Checked = true;
            this.checkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkSound.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkSound.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkSound.Location = new System.Drawing.Point(176, 186);
            this.checkSound.Name = "checkSound";
            this.checkSound.Size = new System.Drawing.Size(96, 18);
            this.checkSound.TabIndex = 12;
            this.checkSound.Text = "Озвучка   ";
            this.checkSound.UseVisualStyleBackColor = true;
            // 
            // checkBox_Block
            // 
            this.checkBox_Block.BackgroundImage = global::BDObarterNEXT.Properties.Resources.dialback_;
            this.checkBox_Block.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox_Block.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_Block.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_Block.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_Block.Location = new System.Drawing.Point(176, 162);
            this.checkBox_Block.Name = "checkBox_Block";
            this.checkBox_Block.Size = new System.Drawing.Size(96, 18);
            this.checkBox_Block.TabIndex = 11;
            this.checkBox_Block.Text = "БлокДраг";
            this.checkBox_Block.UseVisualStyleBackColor = true;
            // 
            // dialButtonReset
            // 
            this.dialButtonReset.BackColor = System.Drawing.SystemColors.Control;
            this.dialButtonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dialButtonReset.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialButtonReset.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dialButtonReset.Location = new System.Drawing.Point(12, 40);
            this.dialButtonReset.Name = "dialButtonReset";
            this.dialButtonReset.Size = new System.Drawing.Size(82, 35);
            this.dialButtonReset.TabIndex = 0;
            this.dialButtonReset.Text = "Сброс";
            this.dialButtonReset.UseVisualStyleBackColor = false;
            this.dialButtonReset.Click += new System.EventHandler(this.dialButtonReset_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImage = global::BDObarterNEXT.Properties.Resources.test2;
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxLogo.Location = new System.Drawing.Point(100, 40);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(172, 116);
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.WaitOnLoad = true;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 268);
            this.Controls.Add(this.checkDeActive);
            this.Controls.Add(this.checkSound);
            this.Controls.Add(this.checkBox_Block);
            this.Controls.Add(this.labelOpacity);
            this.Controls.Add(this.trackBarOpacity);
            this.Controls.Add(this.dialButtonTextOut);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.dialButtonExit);
            this.Controls.Add(this.dialTrackBarScale);
            this.Controls.Add(this.dialButtonBorder);
            this.Controls.Add(this.dialButtonReset);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.panelUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Desktop;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_FormClosing);
            this.Load += new System.EventHandler(this.Dialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dialTrackBarScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.panelUp.ResumeLayout(false);
            this.panelUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dialButtonReset;
        private System.Windows.Forms.TrackBar dialTrackBarScale;
        private System.Windows.Forms.Label labelScale;
        public System.Windows.Forms.Button dialButtonTextOut;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label labelOpacity;
        public System.Windows.Forms.Button dialButtonBorder;
        private System.Windows.Forms.ToolTip toolTipWarning;
        public System.Windows.Forms.Button dialButtonExit;
        public System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.CheckBox checkBox_Block;
        private System.Windows.Forms.CheckBox checkSound;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.CheckBox checkDeActive;
    }
}