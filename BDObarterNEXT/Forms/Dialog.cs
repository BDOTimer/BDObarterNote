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

            this.dialButtonTextOut.BackColor = rgb(255, 200, 200);

            CCforfont    = new Control[2]   ;
            CCforfont[0] = myform.buttonNP  ;
            CCforfont[1] = myform.buttonShow;

            // this.SetDesktopLocation(200, 200); // ???
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
        }

        private static string labelscaletext ;
        private static string labelopacitytext;

        public  static Dialog Create(myForm F)
        {   myform = F;

            Dialog dial         = new Dialog();
                   dial.Owner   = F           ;
                   dial.Show                ();
                   dial.Visible = true        ;

                   labelscaletext    = dial.labelScale.Text;
                   dial.labelScale.Text  = labelscaletext
                                         + Convert.ToString(myForm.cfg.scale);
                   dial.dialTrackBarScale.Value =  myForm.cfg.scale;

                   labelopacitytext = dial.labelOpacity.Text;
                   dial.labelOpacity.Text = labelopacitytext
                                          + Convert.ToString
                                                (dial.trackBarOpacity.Value);
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
        }

        public bool isborder = true;
        private void dialButtonBorder_MouseDown(object sender, MouseEventArgs e)
        {   isborder = !isborder;
            if(isborder) myform.FormBorderStyle = FormBorderStyle.FixedSingle;
            else         myform.FormBorderStyle = FormBorderStyle.None       ;

            if (isborder) this.dialButtonBorder.BackColor = rgb(200, 255, 200);
            else          this.dialButtonBorder.BackColor = rgb(255, 200, 200);

            myForm.showmode.setborder(myform.FormBorderStyle);
        }

        private static Color rgb(int r, int g, int b)
        {   return Color.FromArgb(
                ((int)(((byte)(r)))),
                ((int)(((byte)(g)))),
                ((int)(((byte)(b)))));
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
            {   MyLib.textout.add("myForm.fromdipto_font == null");
                return;
            }

            this.resizefont();
            myform.Refresh ();
        }

        private void dialButtonTextOut_Click(object sender, EventArgs e)
        {
            bool b = MyLib.textout.onoff();

            if  (b) this.dialButtonTextOut.BackColor = rgb(200, 255, 200);
            else    this.dialButtonTextOut.BackColor = rgb(255, 200, 200);

            myForm.apbox.reCorrected(myform);
        }

        public Point getdialTrackBarScaleRange()
        {   return new Point(
                dialTrackBarScale.Minimum,
                dialTrackBarScale.Maximum);
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {   (this.Owner).Opacity = 0.01 * trackBarOpacity.Value;

            this.labelOpacity.Text = labelopacitytext
                                   + Convert.ToString(trackBarOpacity.Value);
        }

        public void set_dialTrackBarScale(int scale)
        {   myForm.cfg.scale        = scale;
            dialTrackBarScale.Value = scale;
        }
    }
}
