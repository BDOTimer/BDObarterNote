namespace BDObarterNEXT
{
    partial class myForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myForm));
            this.panelDest = new System.Windows.Forms.Panel();
            this.panelSources = new System.Windows.Forms.Panel();
            this.textOut = new System.Windows.Forms.TextBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonDialog = new System.Windows.Forms.Button();
            this.buttonNP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelDest
            // 
            this.panelDest.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelDest.Location = new System.Drawing.Point(0, 0);
            this.panelDest.Name = "panelDest";
            this.panelDest.Size = new System.Drawing.Size(460, 52);
            this.panelDest.TabIndex = 0;
            // 
            // panelSources
            // 
            this.panelSources.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panelSources.Location = new System.Drawing.Point(0, 52);
            this.panelSources.Name = "panelSources";
            this.panelSources.Size = new System.Drawing.Size(460, 52);
            this.panelSources.TabIndex = 1;
            // 
            // textOut
            // 
            this.textOut.AcceptsReturn = true;
            this.textOut.BackColor = System.Drawing.SystemColors.MenuText;
            this.textOut.Font = new System.Drawing.Font("Courier New", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textOut.ForeColor = System.Drawing.Color.Lime;
            this.textOut.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textOut.Location = new System.Drawing.Point(0, 106);
            this.textOut.Multiline = true;
            this.textOut.Name = "textOut";
            this.textOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOut.Size = new System.Drawing.Size(460, 140);
            this.textOut.TabIndex = 2;
            this.textOut.Text = "> Test - 2022\r\n...";
            // 
            // buttonShow
            // 
            this.buttonShow.Cursor = System.Windows.Forms.Cursors.PanNE;
            this.buttonShow.Location = new System.Drawing.Point(466, 0);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(50, 50);
            this.buttonShow.TabIndex = 3;
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDown);
            this.buttonShow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseMove);
            this.buttonShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseUp);
            // 
            // buttonDialog
            // 
            this.buttonDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDialog.Location = new System.Drawing.Point(466, 32);
            this.buttonDialog.Name = "buttonDialog";
            this.buttonDialog.Size = new System.Drawing.Size(20, 20);
            this.buttonDialog.TabIndex = 4;
            this.buttonDialog.Text = ".";
            this.buttonDialog.UseVisualStyleBackColor = false;
            this.buttonDialog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDialog_MouseDown);
            // 
            // buttonNP
            // 
            this.buttonNP.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonNP.Location = new System.Drawing.Point(466, 52);
            this.buttonNP.Name = "buttonNP";
            this.buttonNP.Size = new System.Drawing.Size(50, 50);
            this.buttonNP.TabIndex = 5;
            this.buttonNP.Text = "...";
            this.buttonNP.UseVisualStyleBackColor = true;
            this.buttonNP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonNP_MouseUp);
            // 
            // myForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 248);
            this.Controls.Add(this.buttonNP);
            this.Controls.Add(this.buttonDialog);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.textOut);
            this.Controls.Add(this.panelSources);
            this.Controls.Add(this.panelDest);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "myForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BDObarterNote";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.myForm_FormClosing);
            this.Load += new System.EventHandler(this.myForm_Load);
            this.Move += new System.EventHandler(this.myForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDest;
        private System.Windows.Forms.Panel panelSources;
        private System.Windows.Forms.TextBox textOut;
        public System.Windows.Forms.Button buttonShow;
        public System.Windows.Forms.Button buttonDialog;
        public System.Windows.Forms.Button buttonNP;
    }
}

