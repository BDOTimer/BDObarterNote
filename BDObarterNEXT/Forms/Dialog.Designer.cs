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
            this.dialButtonReset = new System.Windows.Forms.Button();
            this.dialButtonBorder = new System.Windows.Forms.Button();
            this.dialTrackBarScale = new System.Windows.Forms.TrackBar();
            this.dialButtonExit = new System.Windows.Forms.Button();
            this.labelScale = new System.Windows.Forms.Label();
            this.dialButtonTextOut = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.toolTipWarning = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dialTrackBarScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // dialButtonReset
            // 
            this.dialButtonReset.Location = new System.Drawing.Point(12, 10);
            this.dialButtonReset.Name = "dialButtonReset";
            this.dialButtonReset.Size = new System.Drawing.Size(82, 23);
            this.dialButtonReset.TabIndex = 0;
            this.dialButtonReset.Text = "Сброс";
            this.dialButtonReset.UseVisualStyleBackColor = true;
            this.dialButtonReset.Click += new System.EventHandler(this.dialButtonReset_Click);
            // 
            // dialButtonBorder
            // 
            this.dialButtonBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.dialButtonBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dialButtonBorder.Location = new System.Drawing.Point(12, 39);
            this.dialButtonBorder.Name = "dialButtonBorder";
            this.dialButtonBorder.Size = new System.Drawing.Size(82, 23);
            this.dialButtonBorder.TabIndex = 1;
            this.dialButtonBorder.Text = "Бордюр";
            this.dialButtonBorder.UseVisualStyleBackColor = false;
            this.dialButtonBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dialButtonBorder_MouseDown);
            // 
            // dialTrackBarScale
            // 
            this.dialTrackBarScale.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.dialTrackBarScale.Location = new System.Drawing.Point(12, 132);
            this.dialTrackBarScale.Maximum = 80;
            this.dialTrackBarScale.Minimum = 20;
            this.dialTrackBarScale.Name = "dialTrackBarScale";
            this.dialTrackBarScale.Size = new System.Drawing.Size(260, 45);
            this.dialTrackBarScale.TabIndex = 2;
            this.dialTrackBarScale.TickFrequency = 2;
            this.dialTrackBarScale.Value = 50;
            this.dialTrackBarScale.ValueChanged += new System.EventHandler(this.dialTrackBarScale_ValueChanged);
            // 
            // dialButtonExit
            // 
            this.dialButtonExit.BackColor = System.Drawing.Color.Gray;
            this.dialButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dialButtonExit.ForeColor = System.Drawing.Color.White;
            this.dialButtonExit.Location = new System.Drawing.Point(207, 227);
            this.dialButtonExit.Name = "dialButtonExit";
            this.dialButtonExit.Size = new System.Drawing.Size(65, 23);
            this.dialButtonExit.TabIndex = 3;
            this.dialButtonExit.Text = "Выход ...";
            this.dialButtonExit.UseVisualStyleBackColor = false;
            this.dialButtonExit.Click += new System.EventHandler(this.dialButtonExit_Click);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(12, 116);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(59, 13);
            this.labelScale.TabIndex = 4;
            this.labelScale.Text = "Масштаб: ";
            // 
            // dialButtonTextOut
            // 
            this.dialButtonTextOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.dialButtonTextOut.Location = new System.Drawing.Point(12, 68);
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
            this.trackBarOpacity.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBarOpacity.Location = new System.Drawing.Point(15, 183);
            this.trackBarOpacity.Maximum = 80;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(79, 45);
            this.trackBarOpacity.TabIndex = 6;
            this.trackBarOpacity.TickFrequency = 10;
            this.trackBarOpacity.Value = 10;
            this.trackBarOpacity.ValueChanged += new System.EventHandler(this.trackBarOpacity_ValueChanged);
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(12, 167);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(85, 13);
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
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelOpacity);
            this.Controls.Add(this.trackBarOpacity);
            this.Controls.Add(this.dialButtonTextOut);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.dialButtonExit);
            this.Controls.Add(this.dialTrackBarScale);
            this.Controls.Add(this.dialButtonBorder);
            this.Controls.Add(this.dialButtonReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_FormClosing);
            this.Load += new System.EventHandler(this.Dialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dialTrackBarScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
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
    }
}