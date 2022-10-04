using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDObarterNEXT
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();

            this.dialButtonTextOut.BackColor = MyLib.rgb(255, 200, 200);

            CCforfont    = new Control[2]   ;
            CCforfont[0] = myform.buttonNP  ;
            CCforfont[1] = myform.buttonShow;

            setButtonBorder(myForm.cfg.formBorderStyle);
        }

        private Control[] CCforfont;
        public void resizefont()
        {   MyLib  .resizefont(
                this  .CCforfont     ,
                myForm.fromdipto_font,
                myForm.cfg.scale
            );
        }

        static myForm myform;

        private void Dialog_Load(object sender, EventArgs e)
        {
            toolTipWarning.SetToolTip(dialButtonExit, "ВЫХОД из программы!");
            toolTipWarning.UseFading = true;
            toolTipWarning.Popup += new PopupEventHandler(toolTipWarning_Popup);
        }

        private static string labelscaletext  ;
        private static string labelopacitytext;

        private void toolTipWarning_Popup(object sender, EventArgs e)
        {   myForm.sounds.play(MySounds.eSND.ATTENTION);
        }

        //-------------------------------------------|
        //  Create                                   |<------------------------|
        //-------------------------------------------:
        static Bitmap jpg;
        public  static Dialog Create(myForm F)
        {   myform = F;
            jpg    = global::BDObarterNEXT.Properties.Resources.dialback_;

            Dialog dial         = new Dialog();
                   dial.Owner   = F           ;
                   dial.Show                ();
                   dial.Visible = myForm.cfg.dialVisible;

                   dial.BackgroundImage = jpg;
            
                   labelscaletext    = dial.labelScale.Text;
                   dial.labelScale.Text  = labelscaletext
                                         + Convert.ToString(myForm.cfg.scale);
                   dial.dialTrackBarScale.Value =  myForm.cfg.scale;

                   labelopacitytext = dial.labelOpacity.Text;

                   int    op = myForm.cfg.transparency;
                   F.Opacity = 0.01 * (100    - op);
                   dial.trackBarOpacity.Value = op ;
                   dial.labelOpacity.Text = labelopacitytext
                                          + Convert.ToString(op);
                   
                   dial.checkBox_Block.Checked = myForm.cfg.is_block;
            return dial;
        }

        //-------------------------------------------|
        //  Управление диалогом.                     |
        //-------------------------------------------:
        public void OnOff()
        {   this.Visible = !this.Visible;
        }

        public  bool isclickexit = false;
        private void dialButtonExit_Click(object sender, EventArgs e)
        {   isclickexit = true;
            myform.Close();
        }

        private void dialButtonReset_Click(object sender, EventArgs e)
        {   myForm.sounds.play(MySounds.eSND.RESET);
            myForm.apbox.reset();
            this.Close();
        }

        const FormBorderStyle BY = FormBorderStyle.FixedSingle;
        const FormBorderStyle BN = FormBorderStyle.None       ;

        //----------------------------------------------------- setButtonBorder:
        public void setButtonBorder(FormBorderStyle a)
        {
            myform.FormBorderStyle = a;

            if (a == BY) this.dialButtonBorder.BackColor = MyLib.rgb(200, 255, 200);
            else         this.dialButtonBorder.BackColor = MyLib.rgb(255, 200, 200);
        }

        //-------------------------------------------------- switchButtonBorder:
        public void switchButtonBorder()
        {
            FormBorderStyle a = myform.FormBorderStyle;

            if (a == BN) setButtonBorder(BY);
            else         setButtonBorder(BN);

            myForm.cfg.formBorderStyle = myform.FormBorderStyle;
        }

        private void dialButtonBorder_MouseDown(object sender, MouseEventArgs e)
        {   switchButtonBorder();
        }

        private void Dialog_FormClosing(object sender, FormClosingEventArgs e)
        {   this.Visible               = false;
            if (!isclickexit) e.Cancel = true ; //<<<---...
        }

        private void dialTrackBarScale_ValueChanged(object sender, EventArgs e)
        {
            myForm.cfg.scale     = dialTrackBarScale.Value;
            this.labelScale.Text = labelscaletext
                                 + Convert.ToString(dialTrackBarScale.Value);

          //myform.SuspendLayout();
            myForm.apbox.reCorrected(myform);
          //myform.ResumeLayout(false);

            if (myForm.fromdipto_font == null)
            {   //MyLib.textout.add("myForm.fromdipto_font == null");
                return;
            }

            this.resizefont();
            myform.Refresh ();
        }

        private void dialButtonTextOut_Click(object sender, EventArgs e)
        {
            bool b = MyLib.textout.onoff();

            if  (b) this.dialButtonTextOut.BackColor = MyLib.rgb(200, 255, 200);
            else    this.dialButtonTextOut.BackColor = MyLib.rgb(255, 200, 200);

            myForm.apbox.reCorrected(myform);
        }

        public Point getdialTrackBarScaleRange()
        {   return new Point(
                dialTrackBarScale.Minimum,
                dialTrackBarScale.Maximum);
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {   setTransparency(trackBarOpacity.Value);
        }

        public void set_dialTrackBarScale(int scale)
        {   myForm.cfg.scale        = scale;
            dialTrackBarScale.Value = scale;
        }

        private void setTransparency(int op)
        {  (this.Owner).Opacity     = 0.01 * (100 - op);
            this.labelOpacity.Text  = labelopacitytext + Convert.ToString(op);
        }

        public bool is_block_drag()
        {   return checkBox_Block.Checked;
        }
    }
}
